using Godot;
using System;

public partial class GameOverUI : Control
{
	[Export] private Button RetryButton;
	[Export] private Button MainMenuButton;
	[Export] private Label ScoreShow;

	public static GameOverUI Instance { get; private set; }

	public override void _Ready()
	{
		Instance = this;
		
		Hide();

        RetryButton.Toggled += RetryButton_Toggled;
        MainMenuButton.Toggled += MainMenuButton_Toggled;
	}
    public override void _Process(double delta)
    {
        int Score = Bird.Instance.GetScore();
        ScoreShow.Text = "Score: " + Score;
    }
    private void MainMenuButton_Toggled(bool buttonPressed)
    {
        GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
    }

    private void RetryButton_Toggled(bool buttonPressed)
    {
		Game.Instance.ResetGame();
		Hide();
    }
}
