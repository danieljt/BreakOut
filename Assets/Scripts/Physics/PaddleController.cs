using UnityEngine;
using UnityEngine.InputSystem;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// This script controls the paddle
    /// </summary>
    public class PaddleController : MonoBehaviour
    {
		public float speed;
        private PlayerInput input;
        private Rigidbody2D body;

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

			}
		}
	}
}
