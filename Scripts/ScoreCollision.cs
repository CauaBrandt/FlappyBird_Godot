using Godot;
using System;

public partial class ScoreCollision : Area2D
{
	public static ScoreCollision Instance { get; private set; }

	public override void _Ready()
	{
		Instance = this;
		AreaEntered += ScoreCollision_AreaEntered;
	}

	private void ScoreCollision_AreaEntered(Area2D area)
	{
		Bird.Instance.ScoreUP();
	}
}
