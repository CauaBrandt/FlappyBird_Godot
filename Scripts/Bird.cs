using Godot;
using System;

public partial class Bird : RigidBody2D
{
	[Export] private float JumpForce = -300.0f;
	[Export] private Label ScoreText;

	private AnimationPlayer Animation;
	private float minHightTube = 125.0f;
	private float maxHeightTube = -230f;
	private int Score = 0;

    public static Bird Instance { get; private set; }

	public override void _Ready()
	{
		Instance = this;
		Animation = GetNode<AnimationPlayer>("AnimationPlayer");
	}
    public void ScoreUP()
	{
		Score++;
		UpdateVisual();
	}
	public override void _PhysicsProcess(double delta)
	{
		Jump((float)delta);
	}
	private void Jump(float delta)
	{
		Vector2 velocity = LinearVelocity;

		if (Input.IsActionJustPressed("Jump") && !TubeCollision.Instance.GetIsHitting() && Game.Instance.IsPlayingState())
		{
			velocity.Y = JumpForce * delta;
			if(Animation.CurrentAnimation != null)
			{
				Animation.Stop();
                Animation.Play("BirdFlyAnim");
            }
            else
            {
                Animation.Play("BirdFlyAnim");
            }
            ApplyImpulse(velocity);
		}
		LinearVelocity = velocity;
		MoveAndCollide(LinearVelocity);
	}
	private void UpdateVisual()
	{
		ScoreText.Text = Score.ToString();
	}
	public int GetScore()
	{
		return Score;
	}
}
