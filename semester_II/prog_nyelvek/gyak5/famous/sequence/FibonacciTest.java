package famous.sequence;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;
// import org.junit.jupiter.params.provider.CsvFileSource;

public class FibonacciTest {
    @Test
    public void fib1() {
        assertEquals(0, Fibonacci.fib(1));
    }

    @ParameterizedTest
    @CsvSource({"1, 0", "2, 1", "10, 34"})
    // @CsvFileSource(resources = "values.csv")
    public void fibs(int n, int expected) {
        assertEquals(expected, Fibonacci.fib(n));
    }
}
