using Godot;
using System;

public partial class TubeCollision : Area2D
{
	[Export] private static bool isHitting = false;

	public static TubeCollision Instance { get; private set; }

	public override void _Ready()
	{
		Instance = this;
		AreaEntered += TubeCollision_AreaEntered;
	}

	private void TubeCollision_AreaEntered(Area2D area)
	{
		isHitting = true;
		GameOverUI.Instance.Show();
	}
	public void SetIsHittingToFalse()
	{
		isHitting = false;
	}
	public bool GetIsHitting()
	{
		return isHitting;
	}
}

