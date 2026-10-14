using Darkthorn.Quest.Nodes.Components.Data;
using Godot;

namespace Darkthorn.Quest.Nodes.Components.Systems;

public partial class MovementSystem : Node
{
	[Export] protected CharacterBody2D TargetBody { get; set; } = default!;
	[Export] protected MovementData MovementData { get; set; } = default!;

	public override void _Ready()
	{
		base._Ready();

		this.TargetBody ??= this.GetNodeOrNull<CharacterBody2D>("../..");
		this.MovementData ??= this.GetNodeOrNull<MovementData>("../../Data/MovementData");
	}

	public override void _PhysicsProcess(double delta)
	{
		if (this.TargetBody is null)
		{ return; }

		if (this.MovementData is null)
		{ return; }
		
		base._PhysicsProcess(delta);

		Vector2 currentVelocity = this.MovementData.InputDirection != Vector2.Zero
			? this.MovementData.InputDirection.Normalized() * this.MovementData.Speed
			: Vector2.Zero;

		this.TargetBody.Velocity = currentVelocity;
		_ = this.TargetBody.MoveAndSlide();
	}
}
