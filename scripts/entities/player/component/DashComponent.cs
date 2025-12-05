using Godot;
namespace PlayerEntityMovement;

public partial class DashComponent : Node
{
    [Export] private Timer _dashCooldown;
    [Export] private float _dashForce = 20f;

    private const int MAX_DASH_COUNT = 1;
    private int _currentDashCount = 0;


    private bool _isDashing = false;

    public override void _Ready()
    {
        _dashCooldown.Timeout += OnTimerCooldown;
    }

    public void PlayerDash(CharacterBody3D _entity)
    {
        var playerDirection = new Vector3(_entity.Velocity.X, 0.0f, _entity.Velocity.Z);

        if (Input.IsActionJustPressed("dash") && MAX_DASH_COUNT > _currentDashCount)
        {
            _currentDashCount++;
            if (_entity.Velocity != Vector3.Zero)
            {
                _entity.Velocity = playerDirection * _dashForce;
            }
            else
            {
                _entity.Velocity = Vector3.Forward * _dashForce;

            }
            
            if (MAX_DASH_COUNT == _currentDashCount) { _dashCooldown.Start(); }
            _entity.MoveAndSlide();
        }

    }



    private void OnTimerCooldown()
    {
        _isDashing = false;
        _currentDashCount = 0;

    }
}

