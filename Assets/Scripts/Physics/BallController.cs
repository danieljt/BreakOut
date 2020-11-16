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

        [Tooltip("The start direction of the ball. This will be normalized")]
        public Vector2 startDirection;

		[Tooltip("The damage done by the ball")]
		public int damage;

        private Rigidbody2D body;
		private IDeath deathInterface;

		/// <summary>
		/// The owner of this ball. By default, this gameobject will be it's own owner.
		/// Remember to set this property on instantiation.
		/// </summary>
		public GameObject Owner { set; get; }

		private void Awake()
		{
			body = GetComponent<Rigidbody2D>();
			deathInterface = GetComponent<IDeath>();
		}
		/// <summary>
		/// Sets the direction and send the ball in that direction with the max speed
		/// </summary>
		/// <param name="direction"></param>
		public void SetDirection(Vector2 direction)
		{
            body.velocity = direction.normalized * maxSpeed;
		}

		/// <summary>
		/// When the ball dies by an attack, it destroyes the owner as long as an owner exists. If the ball
		/// is deactivated or destroyed, this method is not called. You must use the attack system for
		/// this component to work.
		/// </summary>
		private void OnDeath(GameObject killer)
		{
			if (Owner != null)
			{
				IDeath death = Owner.GetComponent<IDeath>();
				if (death != null)
				{
					death.Die(killer);
				}
			}
		}

		/// <summary>
		/// The ball does damage to the gameobject on collision as long as the gameobject has
		/// an IHealth interface attached. The ball then makes an attack with Owner as the
		/// attacker
		/// </summary>
		/// <param name="collision"></param>
		private void OnCollisionEnter2D(Collision2D collision)
		{
			IHealth health = collision.gameObject.GetComponent<IHealth>();
			if(health != null)
			{
				health.LoseHealth(new Attack(Owner, damage));
			}
		}

		private void OnEnable()
		{
			if(deathInterface != null)
			{
				deathInterface.OnDeath += OnDeath;
			}
		}

		private void OnDisable()
		{
			if(deathInterface != null)
			{
				deathInterface.OnDeath -= OnDeath;
			}
		}
	}
}

