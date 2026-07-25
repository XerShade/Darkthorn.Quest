using Darkthorn.Quest.Core;
using Godot;

namespace Darkthorn.Quest.Nodes.Player;

public partial class Player : CharacterBody2D
{
	public override void _Process(double delta) 
		=> base._Process(delta);

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		Vector2 velocity = this.Velocity;

		velocity.X = Input.GetActionStrength("MOVEMENT_RIGHT") - Input.GetActionStrength("MOVEMENT_LEFT");
		velocity.Y = Input.GetActionStrength("MOVEMENT_DOWN") - Input.GetActionStrength("MOVEMENT_UP");

		this.Velocity = velocity.Normalized() * 128;
		_ = this.MoveAndSlide();
	}
}
