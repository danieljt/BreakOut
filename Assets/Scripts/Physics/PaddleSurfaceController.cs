using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// Controls the surface of the paddle. A paddle can affect incoming balls depending on
    /// the collision point on the paddle surface or the paddle speed. By keeping that information
    /// in this class, we can add different scripts
    /// 
    /// </summary>
    public class PaddleSurfaceController : MonoBehaviour
    {
		[Tooltip("The minimum deflection angle from the paddles transform.up")]
		public float minDeflectionAngle;

		[Tooltip("The maximum deflection angle from the paddles transform.up")]
		public float maxDeflectionAngle;

		[Tooltip("The Paddle material. If no material is added, the reflections will be perfect.")]
		public PaddleSurfaceMaterial material;

        private BoxCollider2D paddleCollider;

		private void Awake()
		{
			paddleCollider = GetComponent<BoxCollider2D>();
		}

		/// <summary>
		/// This is where the magic happens. The paddle has an affect on the ball depending on the 
		/// paddle surface material. Since this method comes after fixed update the collision will
		/// already be resolved before this event. This event is therefore a correction of
		/// collision event.
		/// </summary>
		/// <param name="collision"></param>
		private void OnCollisionEnter2D(Collision2D collision)
		{
			BallController ball = collision.gameObject.GetComponent<BallController>();
			if (ball != null)
			{
				Rigidbody2D ballBody = collision.rigidbody;
				if (ballBody != null)
				{
					ContactPoint2D contactPoint = collision.GetContact(0);

					// We check if the collision normal is equal to the paddles transform up.
					// This is the case where we can do fun stuff with the ball reflections
					// Note that the == operator for Vector2s and Vector3s is an 
					// approximatly equal operator.
					if (contactPoint.normal == -(Vector2)transform.up)
					{
						// We find the position of the top center of the collider. This takes rotation
						// into consideration
						Vector2 topMiddle = paddleCollider.bounds.center + transform.up * paddleCollider.size.y / 2;

						// We find the distance between the contact point and the paddle top center
						Vector2 distance = topMiddle - contactPoint.point;

						// We find the signed length from the contact point. We must cast to vector3 to be able to find the sign. We use the 
						// cross product to see if the contact point is to the left or right of the transform up.
						float signedLength = Mathf.Sign(Vector3.Cross((Vector3)distance, (Vector3)contactPoint.normal).z)*distance.magnitude;

						if (material != null)
						{
							// We calculate the new angles added by the collision point from the ball and the paddle velocity
							float posAngle = material.CalculateAngleToAddFromCollision(signedLength, paddleCollider.size.x/2);

							// Calculate the new direction of the ball. Remember, the balls velocity is already reflected from the fixed update, so we
							// must add the angles in a way that is consistent with the outward velocity. 
							Vector3 ballDirection = ballBody.velocity;
							Vector3 newDirection = Quaternion.AngleAxis(posAngle, transform.forward) * ballDirection;
							ball.SetDirection(newDirection);
						}

					}
				}
			}
		}
	}
}
