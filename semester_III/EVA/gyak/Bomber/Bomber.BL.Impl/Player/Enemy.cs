using Bomber.BL.Tiles;
using Bomber.UI.Shared.Units;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Factories;
using GameFramework.Core.Motion;
using GameFramework.Entities;
using GameFramework.Map;
using GameFramework.Map.MapObject;

namespace Bomber.BL.Impl.Player
{
    
    public class Enemy : INpc
    {
        private readonly IEnemyView _view;
        private readonly CancellationToken _stoppingToken;
        private readonly IMap2D _map;
        private Move2D _direction;
        
        public IPosition2D Position { get; private set; }
        public bool IsObstacle => false;

        public Enemy(IEnemyView view, IConfigurationService2D service, IPosition2D position, CancellationToken stoppingToken)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _stoppingToken = stoppingToken;
            service = service ?? throw new ArgumentNullException(nameof(service));
            Position = position;
            _map = service.ActiveMap!;
            _direction = GetRandomMove();
            _view.Load += OnViewLoad;
        }
        
        private void OnViewLoad(object? sender, EventArgs e)
        {
            _view.UpdatePosition(Position);
        }

        public async Task ExecuteAsync()
        {
            while (!_stoppingToken.IsCancellationRequested)
            {
                var newPeriodInSeconds = new Random().Next(1, 3);
                var time = new TimeSpan(0, 0, newPeriodInSeconds);

                using PeriodicTimer timer = new(time);

                if (!await timer.WaitForNextTickAsync(_stoppingToken))
                {
                    continue;
                }
                
                var mapObject = _map.SimulateMove(Position, _direction);
                while (mapObject is null || mapObject.IsObstacle || mapObject is IDeadlyTile || mapObject is INpc)
                {
                    _direction = GetRandomMove();
                    mapObject = _map.SimulateMove(Position, _direction);
                }
                    
                Step(mapObject);
            }
        }
        
        public void SteppedOn(IUnit2D unit2D)
        {
            throw new NotImplementedException();
        }
        
        public void Step(IMapObject2D mapObject)
        {
            if (mapObject is IDeadlyTile || mapObject.IsObstacle)
            {
                _direction = GetRandomMove();
            }
            Position = mapObject.Position;
            _view.UpdatePosition(Position);
        }

        private static Move2D GetRandomMove()
        {
            return new Random().Next(0, 4) switch
            {
                0 => Move2D.Left,
                1 => Move2D.Right,
                2 => Move2D.Forward,
                3 => Move2D.Backward,
                _ => throw new InvalidOperationException("Unsupported move!")
            };
        }
    }
}
