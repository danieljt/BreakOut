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

		private PaddleController PaddleController;
        private BoxCollider2D paddleCollider;

		private void Awake()
		{
			PaddleController = GetComponent<PaddleController>();
			paddleCollider = GetComponent<BoxCollider2D>();
		}

		/// <summary>
		/// This is where the magic happens. The paddle has an affect on the ball depending on the 
		/// paddle surface material
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

					// We check if the collision normal is equal to the paddles transform up.
					// This is the case where we can do fun stuff with the ball reflections
					// Note that the == operator for Vector2s and Vector3s is an 
					// approximatly equal operator.
					if (collision.GetContact(0).normal == -(Vector2)transform.up)
					{
						// We find the position of the top center of the collider. This takes rotation
						// into consideration
						Vector2 topMiddle = paddleCollider.bounds.center + transform.up * paddleCollider.size.y / 2;

						// We find the point of collision in world space
						Vector2 contactPoint = collision.GetContact(0).point;

						// Then the distance between the contact point and the paddle top center
						Vector2 distance = topMiddle - contactPoint;

						// We find the signed length from the contact point. We must cast to vector3 to be able to find the sign. We use the 
						// cross product to see if the contact point is to the left or right of the transform up.
						float signedlength = Mathf.Sign(Vector3.Cross((Vector3)distance, (Vector3)collision.GetContact(0).normal).z)*distance.magnitude;

						// We find the signed velocity along the paddles transform.right axis by using the cross product
						float signedVelocity = Mathf.Sign(Vector3.Cross((Vector3)collision.otherRigidbody.velocity, transform.up).z) * collision.otherRigidbody.velocity.magnitude;
						if (material != null)
						{

							// We calculate the new rotation with the angles added from the contact point and the paddle velocity
							float posAngle = material.CalculateAngleToAddFromCollision(signedlength, paddleCollider.size.x);
							float velAngle = material.CalculateAngleToAddFromVelocity(signedVelocity, PaddleController.speed);
							Quaternion newAngle = Quaternion.AngleAxis(Vector3.SignedAngle(transform.up, collision.rigidbody.position, transform.forward) + posAngle + velAngle, Vector3.forward);
							ball.SetDirection(newAngle * transform.up);
						}

					}
				}
			}
		}
	}
}
