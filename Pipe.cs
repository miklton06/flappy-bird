using Godot;
using System;

public partial class Pipe : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	Vector2 speed = new Vector2(400, 0);
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		Position -= speed *(float)delta;
	}

	public void ScreenExited(){
		QueueFree();
	}
}
