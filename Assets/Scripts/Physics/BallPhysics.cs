using System.Collections;
using System.Collections.Generic;
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
        [Tooltip("This is the maximum speed of the ball")]
        public float maxSpeed;

        /// <summary>
        /// We use this method to script in custom collision responses that are both unrealistic and fun.
        /// Consider adding more fun responses in this method
        /// </summary>
        /// <param name="collision"></param>
		private void OnCollisionEnter2D(Collision2D collision)
		{
			
		}
	}
}

