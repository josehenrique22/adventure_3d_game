using Godot;
namespace PlayerEntityMovement;

public partial class DashComponent : Node
{
    // TODO: Estudar melhor a logica do Dash 
    // QUEBRE POR PARTES, FAÇA COMPONENT A COMPONENT E SEMPRE TESTANDO

    /*
        Player usar dash na direção onde estiver andando no ter um limite de quantos dash pode ser usado de uma vez no caso 2
        ter um tempo de cooldown
        se nada for precionado player dar um dash para frente
    */
    [Export] private Timer _dashCooldownTimer;
    [Export] private float _dashVelocity;

    private const int MAX_DASH_COUNTER = 1;
    private int _currentDashCounter;
    private Vector3 _currentDirection = Vector3.Zero;


    public override void _Ready()
    {
        _dashCooldownTimer.Timeout += OnTimeOut;
    }

    public void PlayerEntityDash(CharacterBody3D _entity)
    {
        PlayerDashVelocity(_entity);

        if (Input.IsActionJustPressed("dash") && MAX_DASH_COUNTER > _currentDashCounter)
        {
            ApplyDash(_entity);

            if (MAX_DASH_COUNTER == _currentDashCounter)
            {
                _dashCooldownTimer.Start();
            }
        }
    }

    private void ApplyDash(CharacterBody3D _entity)
    {
        _entity.Velocity = _currentDirection;
        _currentDashCounter++;
        _ = _entity.MoveAndSlide();
        GD.Print($"Number of Dash: {_currentDashCounter}");
    }

    private void PlayerDashVelocity(CharacterBody3D _entity)
    {
        float dashFowardMultiply = 3.5f;
        _currentDirection = _entity.Velocity != Vector3.Zero ?
                _currentDirection = _entity.Velocity * _dashVelocity :
                _currentDirection = Vector3.Forward * _dashVelocity * dashFowardMultiply;
        
    }

    private void OnTimeOut()
    {
        _currentDashCounter = 0;
    }

}

