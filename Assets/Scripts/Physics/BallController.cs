using StupidGirlGames.HealthSystem;
using StupidGirlGames.AttackSystem;
using UnityEngine;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// Custom physics class for the ball in the breakout game. Due to the game being highly 
    /// unrealistic and simplified, the ball is given this simple physics script as an addon
    /// to give fun collision responses and to counter floating point errors
    /// </summary>
    public class BallController : MonoBehaviour
    {
        [Tooltip("This is the maximum speed of the ball. Must be more than 1 to account for the bounce threeshold")]
        [Range(1.0f, 10f)]
        public float maxSpeed;

        [Tooltip("This is the damage done by the ball")]
        public int damage;

        [Tooltip("The start direction of the ball. This will be normalized")]
        public Vector2 startDirection;

        private Rigidbody2D body;

		/// <summary>
		/// The owner of this ball. By default, this gameobject will be it's own owner.
		/// Remember to set this property on instantiation.
		/// </summary>
		public GameObject Owner { set; get; }

		private void Awake()
		{
			body = GetComponent<Rigidbody2D>();
		}
		/// <summary>
		/// Sets the direction and send the ball in that direction with the max speed
		/// </summary>
		/// <param name="direction"></param>
		public void SetDirection(Vector2 direction)
		{
            body.velocity = direction.normalized * maxSpeed;
		}

		private void OnDisable()
		{
			if(Owner != null)
			{
				IDeath death = Owner.GetComponent<IDeath>();
				if(death != null)
				{
					death.Die(new Attack(gameObject, 1));
				}
			}
		}
	}
}

