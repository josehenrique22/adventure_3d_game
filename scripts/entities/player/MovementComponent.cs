using Godot;

namespace PlayerEntityMovement;
public partial class MovementComponent : Node
{
    [Export] private float _speed = 0.0f;
    [Export] private float _acceleration = 0.0f;
    [Export] private float _deceleration = 0.0f;

    public void PlayerEntityMovement(CharacterBody3D _entity, double _delta)
    {
        float xAxis = Input.GetAxis("left", "right");
        float zAxis = Input.GetAxis("foward", "backwards");

        Vector3 direction = new Vector3(xAxis, 0.0f, zAxis) * _speed;

        var playerIsMoving = direction != Vector3.Zero;

        if (!_entity.IsOnFloor())
        {
            _entity.Velocity = _entity.GetGravity();
        }

        if (playerIsMoving)
        {
            direction.Normalized();
        }

        float playerSpeedInterpolation = playerIsMoving ?
         _acceleration * (float)_delta
         : _deceleration * (float)_delta;

        _entity.Velocity = direction * playerSpeedInterpolation;
        _entity.MoveAndSlide();
    }
}
