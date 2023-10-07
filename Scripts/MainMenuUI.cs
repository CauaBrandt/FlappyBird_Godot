using Godot;
using System;

public partial class MainMenuUI : Control
{
	[Export] private Button PlayButton;
	[Export] private Button QuitButton;

    public override void _Ready()
    {
        PlayButton.Toggled += PlayButton_Toggled;
        QuitButton.Toggled += QuitButton_Toggled;
    }

    private void QuitButton_Toggled(bool buttonPressed)
    {
        GetTree().Quit();
    }

    private void PlayButton_Toggled(bool buttonPressed)
    {
        GetTree().ChangeSceneToFile("res://Scenes/Game.tscn");
    }
}
