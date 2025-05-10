using Godot;

namespace Game.MovableObject;

public partial class MovableObject : Node2D
{
	private readonly StringName ACTION_MOVE_UP = "move_up";
	private readonly StringName ACTION_MOVE_DOWN = "move_down";
	private readonly StringName ACTION_MOVE_LEFT = "move_left";
	private readonly StringName ACTION_MOVE_RIGHT = "move_right";

	private int movementSpeed = 64; 
	private Vector2 initialPosition = new Vector2(100, 100); // Example initial position

	private AnimationPlayer _animationPlayer;

	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		GlobalPosition = initialPosition;
	}

	public override void _Process(double delta)
	{
		var movementVector = Input.GetVector(ACTION_MOVE_LEFT, ACTION_MOVE_RIGHT, ACTION_MOVE_UP, ACTION_MOVE_DOWN);
		GlobalPosition += movementVector * movementSpeed * (float)delta;

		// Change animation type
		if	(movementVector.X > 0)
			{
			_animationPlayer.Play("move_right");
			}
		else
			{
			_animationPlayer.Stop();
			}
	}
}
