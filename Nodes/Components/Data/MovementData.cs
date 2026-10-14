using Godot;

namespace Darkthorn.Quest.Nodes.Components.Data;

public partial class MovementData : Node
{
	[Export] public float Speed { get; set; } = 128f;

	[Export] public Vector2 InputDirection { get; set; } = Vector2.Zero;
}
