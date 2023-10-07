using Godot;
using System;

public partial class Game : Node2D
{
	[Export] private Node2D bird;
	[Export] private Node2D GetReady;
	[Export] private Label Tutorial;
	[Export] private PackedScene tube { get; set; }

	private int TubeSpawnedAmount = 0;
	private float minHightTube = 115f;
	private float maxHeightTube = -115f;
	private Timer timer;

	public static Game Instance { get; private set; }

	private enum GameState
	{
		Waiting,
		Playing,
		GameOver,
		GameWin
	}

	private GameState state;

	public override void _Ready()
	{
		Instance = this;

		Bird.Instance.Freeze = true;
		state = GameState.Waiting;

		timer = GetNode<Timer>("SpawnTubeTimer");
		timer.Timeout += Timer_Timeout;
	}
    public override void _Process(double delta)
	{
        
        switch (state)
		{
			case GameState.Waiting:
				TubeCollision.Instance.SetIsHittingToFalse();
				GetReady.Visible = true;
				Tutorial.Visible = true;
				Bird.Instance.Freeze = true;
				if(Input.IsAnythingPressed())
				{
					state = GameState.Playing;
					GetReady.Visible = false;
					Tutorial.Visible = false;
					Bird.Instance.Freeze = false;
					SpawnTube();
					timer.Start();
				}
				break; 
			case GameState.Playing:
				int Score = Bird.Instance.GetScore();

                if (TubeCollision.Instance.GetIsHitting())
                {
					state = GameState.GameOver;
                }
				if(Score == 999)
				{
					state = GameState.GameWin;
				}
                break;
			case GameState.GameOver:
				timer.Stop();
				GameOverUI.Instance.Show();
				break;
			case GameState.GameWin:
				timer.Stop();
				GameWin.Instance.Show();
				break;
		}
	}
	private void Timer_Timeout()
	{
		SpawnTube();
	}
	private void SpawnTube()
	{
		float RandomY = (float)GD.RandRange(minHightTube, maxHeightTube);
		Tube newTube = tube.Instantiate<Tube>();

		AddChild(newTube);
		newTube.MoveLocalY(RandomY);
		newTube.MoveLocalX(600);
		TubeSpawnedAmount++;
	}
	public void ResetGame()
	{
		GetTree().ReloadCurrentScene();
    }
	public bool IsPlayingState()
	{
		if (state == GameState.Playing)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
