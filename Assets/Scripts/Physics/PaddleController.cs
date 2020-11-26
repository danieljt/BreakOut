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

		private void Awake()
		{
            input = GetComponent<PlayerInput>();
            body = GetComponent<Rigidbody2D>();
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
	}
}
