using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A paddle surface material holds information about the surface characteristics of a paddle.
/// When the ball hits the paddle the distance from the center has an affect on the outgoing 
/// angle. The paddle speed can also have an affect, and these characteristics are in this class
/// </summary>
[CreateAssetMenu(menuName = "CustomPhysics/PaddleSurfaceMaterial")]
public class PaddleSurfaceMaterial : ScriptableObject
{
	[Tooltip("The maximum added angle from collision with the paddle. The added angle will never go beyond this")]
	public float maximumAngleToAddFromCollision;

	[Tooltip("The sweetspot of the paddle. When the ball hits a position within the sweet spot, no angle is added")]
	public float sweetSpotDistance;

	[Tooltip("The maximum added angle from the paddle velocity")]
	public float maximumAngleToAddFromVelocity;

	[Tooltip("The minimum velocity needed to add an angle from velocity")]
	public float minimumVelocity;

	/// <summary>
	/// Calculates an angle to add to a reflection of a ball from the paddle. The angle added is dependent on the position from the center of the 
	/// paddle. The angle never exceeds the maximumangleToAdd This method uses a linear model.
	/// </summary>
	/// <param name="positionFromCenter"></param>
	/// <param name="width"></param>
	/// <returns></returns>
	public float CalculateAngleToAddFromCollision(float positionFromCenter, float width)
	{
		return positionFromCenter < sweetSpotDistance ? 0 : maximumAngleToAddFromCollision*positionFromCenter/width;
	}

	/// <summary>
	/// Calculates an angle to add from the velocity of the paddle. The speed of the paddle must be larger than the minimumVelocity to
	/// take affect. The angle also never exceeds the maximumAngleToAddFromVelocity.
	/// </summary>
	/// <param name="velocity"></param>
	/// <param name="maxVelocity"></param>
	/// <returns></returns>
	public float CalculateAngleToAddFromVelocity(float velocity, float maxVelocity)
	{
		return velocity < minimumVelocity ? 0 : (velocity < maxVelocity ? maximumAngleToAddFromVelocity * velocity / maxVelocity : maxVelocity);
	}
}
