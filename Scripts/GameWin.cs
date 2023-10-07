using Godot;
using System;

public partial class GameWin : Control
{
    [Export] private Button AgainButton;
    [Export] private Button MainMenuButton;

    public static GameWin Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;

        Hide();

        AgainButton.Toggled += AgainButton_Toggled;
        MainMenuButton.Toggled += MainMenuButton_Toggled;
    }

    private void MainMenuButton_Toggled(bool buttonPressed)
    {
        GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
    }

    private void AgainButton_Toggled(bool buttonPressed)
    {
        Game.Instance.ResetGame();
        Hide();
    }
}
