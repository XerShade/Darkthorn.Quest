using Darkthorn.Quest.Core;
using Darkthorn.Quest.Nodes.Components.Data;
using Godot;

namespace Darkthorn.Quest.Nodes.Player;

public partial class Player : CharacterBody2D
{
	protected Node Data { get; set; } = default!;
	protected Node Systems { get; set; } = default!;

	protected MovementData MovementData { get; set; } = default!;

	public override void _Ready()
	{
		base._Ready();

		this.Data ??= this.GetNode("Data");
		this.Systems ??= this.GetNode("Systems");

		this.MovementData ??= this.Data.GetNode<MovementData>("MovementData");
	}

	public override void _Process(double delta) 
		=> base._Process(delta);

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		Vector2 inputVelocity = this.Velocity;

		inputVelocity.X = Input.GetActionStrength("MOVEMENT_RIGHT") - Input.GetActionStrength("MOVEMENT_LEFT");
		inputVelocity.Y = Input.GetActionStrength("MOVEMENT_DOWN") - Input.GetActionStrength("MOVEMENT_UP");

		this.MovementData.InputDirection = inputVelocity;

		GameEngine.Instance.Camera.Position = this.Position;
	}
}
