using Godot;

namespace PlayerEntityMovement;

    public partial class MovementComponent : Node
    {
        [ExportCategory("Movement Properties")]
        [Export] private float _speed = 0.0f;
        [Export] private float _acceleration = 0.0f;
        [Export] private float _deceleration = 0.0f;

                private bool _playerIsMoving = false;

        public void PlayerEntityMovement(CharacterBody3D _entity, double _delta)
        {

            if (!_entity.IsOnFloor()) { _entity.Velocity = _entity.GetGravity(); }

        _playerIsMoving = GetEntityDirection() != Vector3.Zero;
        if (_playerIsMoving)
        {
            GetEntityDirection().Normalized();
        }

        _entity.Velocity = GetEntityDirection() * EntityMovementFriction(_delta);
            _entity.MoveAndSlide();

        }

        private Vector3 GetEntityDirection()
        {
            float xAxis = Input.GetAxis("left", "right");
            float zAxis = Input.GetAxis("foward", "backwards");

            Vector3 direction = new Vector3(xAxis, 0.0f, zAxis) * _speed;
        return direction;
        }

    private float EntityMovementFriction(double _delta)
    {
        float playerSpeedInterpolation = _playerIsMoving ?
         _acceleration * (float)_delta
         : _deceleration * (float)_delta;

        return playerSpeedInterpolation;
    }
}
