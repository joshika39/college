package farm;

import farm.animals.Dog;
import farm.animals.Sheep;
import farm.objects.Empty;
import farm.objects.Gate;
import farm.objects.Wall;

import java.util.Random;

public class Farm {
    private final Cell[][] grid;
    private final int width;
    private final int height;
    private boolean simulationRunning = true;

    public Farm(int width, int height) {
        this.width = width;
        this.height = height;
        this.grid = new Cell[height][width];
        initializeFarm();
    }

    private void initializeFarm() {
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                if (i == 0 || i == height - 1 || j == 0 || j == width - 1) {
                    grid[i][j] = new Cell(new Wall());
                } else {
                    grid[i][j] = new Cell(new Empty());
                }
            }
        }

        placeGates();
        placeSheepAndDogs(10, 5);
    }

    private void placeGates() {
        Random random = new Random();
        for (int i = 0; i < 4; i++) {
            int position;
            if (i % 2 == 0) { // Felső vagy alsó fal
                position = random.nextInt(width - 2) + 1;
                grid[i == 0 ? 0 : height - 1][position] = new Cell(new Gate());
            } else { // Bal vagy jobb fal
                position = random.nextInt(height - 2) + 1;
                grid[position][i == 1 ? 0 : width - 1] = new Cell(new Gate());
            }
        }
    }

    private void placeSheepAndDogs(int sheepCount, int dogCount) {
        Random random = new Random();

        for (int i = 0; i < sheepCount; i++) {
            int x, y;
            do {
                x = height / 3 + random.nextInt(height / 3);
                y = width / 3 + random.nextInt(width / 3);
            } while (!(grid[x][y].getContent() instanceof Empty));
            Sheep sheep = new Sheep(x, y, this);
            grid[x][y].setContent(sheep);
            sheep.start();
        }

        for (int i = 0; i < dogCount; i++) {
            int x, y;
            do {
                x = random.nextInt(height);
                y = random.nextInt(width);
            } while (!(grid[x][y].getContent() instanceof Empty));
            Dog dog = new Dog(x, y, this);
            grid[x][y].setContent(dog);
            dog.start();
        }
    }

    public Cell getCell(int x, int y) {
        return grid[x][y];
    }

    public synchronized boolean isRunning() {
        return simulationRunning;
    }

    public synchronized void stopSimulation() {
        simulationRunning = false;
    }

    public void startSimulation() {
        while (simulationRunning) {
            displayFarm();
            try {
                Thread.sleep(200);
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
            }
        }
    }

    public void displayFarm() {
        System.out.print("\033[H\033[2J"); // Clear screen
        for (Cell[] row : grid) {
            for (Cell cell : row) {
                System.out.print(cell.getContent().toString());
            }
            System.out.println();
        }
    }
}