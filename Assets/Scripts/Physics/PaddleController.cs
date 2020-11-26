using UnityEngine;
using UnityEngine.InputSystem;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// This script controls the paddle
    /// </summary>
    public class PaddleController : MonoBehaviour
    {
		[Tooltip("Speed of the paddle")]
		public float speed;

		[Tooltip("The ball that this paddle spawns")]
		public GameObject ballPrefab;

		[Tooltip("The maximum launch angle (Also includes negative values)")]
		public float maxLaunchAngle;

        private PlayerInput input;
        private Rigidbody2D body;
		private GameObject ball;
		private BoxCollider2D box;

		private void Awake()
		{
            input = GetComponent<PlayerInput>();
            body = GetComponent<Rigidbody2D>();
			box = GetComponent<BoxCollider2D>();
		}

		private void OnEnable()
		{
			input.onActionTriggered += HandleMove;
			input.onActionTriggered += HandleFire;
		}

		private void OnDisable()
		{
			input.onActionTriggered -= HandleMove;
			input.onActionTriggered -= HandleFire;

		}

		/// <summary>
		/// Handle the player pressing Move
		/// </summary>
		/// <param name="context"></param>
		private void HandleMove(InputAction.CallbackContext context)
		{
			if(context.action.name == "Move")
			{
				Vector2 move = context.ReadValue<Vector2>();
				if (move != null)
				{
					body.velocity = new Vector2(move.x, 0)*speed;
				}
			}
		}

		/// <summary>
		/// Hadle the player pressing fire
		/// </summary>
		/// <param name="context"></param>
        private void HandleFire(InputAction.CallbackContext context)
		{
			if(context.action.name == "Fire")
			{
				LaunchBall();
			}
		}

		/// <summary>
		/// Launches a new ball in a direction between the negative and positive maxLaunchAngle with respect
		/// to the paddles transform up. A ball is only launched if a prefab with a ballcontroller is
		/// set up in the inspector.
		/// </summary>
		private void LaunchBall()
		{
			if (ball == null)
			{	
				ball = Instantiate(ballPrefab);
				ball.transform.position = transform.position + transform.up*0.5f;
				BallController ballController = ball.GetComponent<BallController>();
				if(ballController != null)
				{
					ballController.Owner = this.gameObject;
					float angle = Random.Range(-maxLaunchAngle, maxLaunchAngle);
					Vector3 direction = Quaternion.AngleAxis(angle, transform.forward)*transform.up;
					ballController.SetDirection(direction);
				}
			}
		}

		/// <summary>
		/// This is where the collision and reflection occurs
		/// </summary>
		/// <param name="collision"></param>
		private void OnCollisionEnter2D(Collision2D collision)
		{
			BallController ball = collision.gameObject.GetComponent<BallController>();
			if(ball != null)
			{
				Rigidbody2D ballBody = collision.gameObject.GetComponent<Rigidbody2D>();
				if(ballBody != null)
				{

					// We check if the collision normal is equal to the paddles transform up.
					// This is the case where we can do fun stuff with the ball reflections
					// Note that the == operator for Vector2s and Vector3s is an 
					// approximatly equal operator.
					if(collision.GetContact(0).normal == -(Vector2)transform.up)
					{
						// We find the position of the top center of the collider. This takes rotation
						// into consideration
						Vector2 topMiddle = box.bounds.center + transform.up * box.size.y / 2;

						// We find the point of collision in world space
						Vector2 contactPoint = collision.GetContact(0).point;

						// Then the distance between them
						Vector2 distance = topMiddle - contactPoint;
						float length = distance.magnitude;
						float angle = CalculateDeflectionAngle(length, box.size.x, 0, maxLaunchAngle);
						Debug.Log(angle);
					}
				}
			}
		}

		/// <summary>
		/// Calculates a new angle for the ball. The balls angle is dependent on where it hits the
		/// paddle. In the center the deflection is perfectly reflected, but is more and more
		/// bent the further away it is from the center. The angle is never smaller than minAngle
		/// and never larger than maxAngle. The method uses a linear scale 
		/// </summary>
		/// <param name="position"></param>
		/// <param name="width"></param>
		/// <param name="minAngle"></param>
		/// <param name="maxAngle"></param>
		/// <returns></returns>
		private float CalculateDeflectionAngle(float position, float width, float minAngle, float maxAngle)
		{
			return maxAngle + (minAngle - maxAngle) / 2 * (position / width + 1);
		}
	}
}
