using Godot;
using System;
using System.ComponentModel;

public partial class FlappyBird : Node
{
	int score= 0;
	[Export]
	public PackedScene pipeScene {get; set;}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnTimerTimeout(){
		// random multi för höjd på pipe
		Random rand = new Random();
		
		
		GD.Print("timeout");
	
		
		Pipe mPipe = pipeScene.Instantiate<Pipe>();
		mPipe.Position = GetNode<Marker2D>("pipeSpawn").Position;
		var offset = new Vector2(0, rand.Next(-150, 150));
		mPipe.Position += offset;
		AddChild(mPipe);
		
		}

		public void OnBirdCollide(){
			
			GD.Print("collition with P/G");
			GetTree().Paused = true ;
			
		}

		public void AddToScore(){
			
			score += 1;
			GD.Print("add to score");
			GetNode<Label>("Score").Text = "Score:" + Convert.ToString(score);  

		}
		public void RestartPressed(){
			GetTree().Paused = false ;
			GetTree().ReloadCurrentScene();
		}

	}
