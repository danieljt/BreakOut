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
    public class BallPhysics : MonoBehaviour
    {
        [Tooltip("This is the maximum speed of the ball. Must be more than 1 to account for the bounce threeshold")]
        [Range(1.0f, 10f)]
        public float maxSpeed;

        [Tooltip("This is the damage done by the ball")]
        public int damage;

        [Tooltip("The start direction of the ball. This will be normalized")]
        public Vector2 startDirection;

        private Rigidbody2D body;
		private GameObject owner;

        /// <summary>
        /// The owner of this ball
        /// </summary>
        public GameObject Owner
		{
			set { owner = value; }
			get { return owner; }
		}

		private void Awake()
		{
            body = GetComponent<Rigidbody2D>();
		}

		private void Start()
		{
            body.velocity = startDirection.normalized*maxSpeed;
		}

        /// <summary>
        /// We compute special collision responses to certain objects
        /// </summary>
        /// <param name="collision"></param>
		private void OnCollisionEnter2D(Collision2D collision)
		{
            IHealth healthInterface = collision.gameObject.GetComponent<IHealth>();
            if(healthInterface != null)
			{
                healthInterface.LoseHealth(new Attack(owner, damage));
			}
		}

        /// <summary>
        /// Sets the direction and send the ball in that direction with the max speed
        /// </summary>
        /// <param name="direction"></param>
        public void SetDirection(Vector2 direction)
		{
            body.velocity = direction.normalized * maxSpeed;
		}
	}
}

