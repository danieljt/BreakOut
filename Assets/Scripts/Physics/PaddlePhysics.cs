using UnityEngine;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// Specialized physics for the paddle. The paddle imposes physics responses
    /// on the gameobjects that collide with it. The most obvious example being the
    /// ball. The paddle reflects the incoming gameobject, but adds a small error
    /// to this reflection depending on it's tangential speed and the point of 
    /// impact from the paddle centre.
    /// </summary>
    public class PaddlePhysics : MonoBehaviour
    {
        [Tooltip("This is the maximum velocity change that can occur by the collision position of the paddle")]
        public float maxPositionCoeff;

        [Tooltip("This is the sweet spot of the paddle. Any collision inside the sweetspot is perfectly reflected. It is calculated as a lenght from the paddle centre")]
        public float sweetSpot;

        [Tooltip("This is the maximum velocity change that can occur by the paddles tangential velocity")]
        public float maxVelocityCoeff;

        /// <summary>
        /// This is where the magic happens. When a gameobject with a collider collides with this paddle it is 
        /// reflected in a way that can be slightly controlled by the player. We choose to add the physics here as
        /// the ball should not be affected in the same way by other gameobjects.
        /// </summary>
        /// <param name="collision"></param>
		private void OnCollisionEnter2D(Collision2D collision)
		{
            
		}
        
        /// <summary>
        /// This is where we calculate the tangential impulse added by the position of the collision with respect to
        /// the paddle centre
        /// </summary>
        private void CalculatePositionInmpulse(Vector2 tangentialVelocity)
		{
            
		}

        /// <summary>
        /// This is where we add the tangential impulse added by the speed of the paddle.
        /// </summary>
        private void CalculateVelocityImpulse(Vector2 tangentialVelocity)
		{

		}

	}
}
