using Darkthorn.Quest.Nodes.Player;
using Godot;
using System;

namespace Darkthorn.Quest.Core;

/// <summary>
/// Defines the core game engine class for Darkthorn.Quest.
/// </summary>
/// <remarks>Contains a singleton instance of the GameEngine class that is used to access the game engine from anywhere in the game.</remarks>
public partial class GameEngine : Node
{
    /// <summary>
    /// Gets the singleton instance of the GameEngine class.
    /// </summary>
	public static GameEngine Instance { get; private set; }

    /// <summary>
    /// Gets the player node.
    /// </summary>
    public Player Player { get; private set; }

    /// <inheritdoc />
    public override void _EnterTree()
    {
        // Invoke the base class implementation of _EnterTree.
        base._EnterTree();

        // Check if an instance of GameEngine already exists.
        if (Instance is not null)
        {
            // If an instance already exists, throw an exception to prevent multiple instances.
            throw new InvalidOperationException("GameEngine is already initialized, only one instance is allowed.");
        }

        // Assign the current instance to the static property.
        Instance = this;
        this.Player = this.GetNode<Player>("Player");
    }

    /// <inheritdoc />
    public override void _ExitTree()
    {
        // Invoke the base class implementation of _ExitTree.
        base._ExitTree();

        // Dispose of the player node if it exists.
        this.Player?.Dispose();
        this.Player = null;

        // Dispose of the instance.
        Instance?.Dispose();
        Instance = null;
    }

    /// <inheritdoc />
    public override void _Ready()
		=> base._Ready();

	/// <inheritdoc />
	public override void _Process(double delta)
		=> base._Process(delta);
}
