using Global;
using Global.Data;
using Global.Data.EffectSystem;
using Godot;

namespace HippieFall.Tunnels
{
    
    class Saw : Obstacle, IEffectable
    {
        private float _d;
        private int _direction;
        [Export] private float _radius;
        [Export] private float _speed;
        [Export] private NodePath _movingObstaclePath;
        private Spatial _movingObstacle;
        private float _x;
        private float _y;

        public override void _Ready()
        {
            _movingObstacle = GetNode<Spatial>(_movingObstaclePath);
            _direction = Utilities.GetRandomNumberInt(-1, 1, Utilities.Parameter.WITH_OUT_ZERO);
            _d = Utilities.GetRandomNumberFloat(-180, 180);
        }
        
        public override void _PhysicsProcess(float delta)
        {
            CircleMoving(delta);
        }

        private void CircleMoving(float delta)
        {
            //x^2 + z^2 = radius^2
            _d += delta * _speed * Mathf.Sign(_direction);
            _x = Mathf.Sin(_d) * _radius;
            _y = Mathf.Cos(_d) * _radius;
            _movingObstacle.RotateZ(_speed);
            _movingObstacle.Translation = new Vector3(_x, _y, 0);
        }

        public void ChangeConfigData(Config config)
        {
            SawConfig obstacleConfig = config as SawConfig;
            _radius = obstacleConfig.Radius;
            _speed = obstacleConfig.Speed;
        }
    }
}