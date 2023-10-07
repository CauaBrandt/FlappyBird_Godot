using Godot;
using System;

public partial class Tube : RigidBody2D
{
	[Export] private float TubeSpeed = 5f;
	[Export] private RayCast2D rayCast;

	public override void _Process(double delta)
	{
		if(rayCast.IsColliding())
		{
			QueueFree();
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		if (!TubeCollision.Instance.GetIsHitting())
		{
			Vector2 velocity = LinearVelocity;

			velocity.X = -(TubeSpeed * (float)delta);
			MoveLocalX(velocity.X);
		}
	}
}
