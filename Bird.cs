using Godot;
using System;
using System.Text.RegularExpressions;

public partial class Bird : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -300.0f;
	[Signal]
	public delegate void BirdCollideEventHandler();

	[Signal]
	public delegate void AddToScoreEventHandler();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("Jump"))
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.


		Velocity = velocity;
		MoveAndSlide();
	}
	public void PipebodyEntered(Node2D body){
		if(body is Bird){
			GD.Print("Pipe collided with bird");
		}

	}
	public void BoduEnteredBird(Rid rid, Area2D body, int areaIndex, int shapeIndex){


		if( body is Pipe || body.Name == "Ground" || body.Name =="Top"){
			GD.Print("collition with" + body.Name);
			GD.Print("area: " + areaIndex);
		
			if (areaIndex == 4 ){
				EmitSignal(SignalName.AddToScore);
			}
				else {
					EmitSignal(SignalName.BirdCollide);
				}
			
		}	

	}
	
}
