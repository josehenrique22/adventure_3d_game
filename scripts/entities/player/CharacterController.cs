using Godot;
using PlayerEntityMovement;
public partial class CharacterController : CharacterBody3D
{
   
    [Export] private MovementComponent _playerEntityMovementComponent;

    public override void _PhysicsProcess(double delta)
    {
        _playerEntityMovementComponent.PlayerEntityMovement(this, delta);
    }
}
