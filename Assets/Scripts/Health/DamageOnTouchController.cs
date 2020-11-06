using StupidGirlGames.HealthSystem;
using UnityEngine;

namespace StupidGirlGames.AttackSystem
{
    /// <summary>
    /// Invoke damage on an incoming object on collision. An incoming object
    /// must have an IHealth interface to recieve damage
    /// </summary>
    public class DamageOnTouchController : MonoBehaviour
    {
        public int damage;

		private void OnCollisionEnter2D(Collision2D collision)
		{
            IHealth healthinterface = collision.gameObject.GetComponent<IHealth>();
            if(healthinterface != null)
			{
                healthinterface.LoseHealth(new Attack(this.gameObject, damage));
			}
		}
	}
}
