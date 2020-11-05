using System;
using UnityEngine;
using StupidGirlGames.AttackSystem;

namespace StupidGirlGames.HealthSystem
{
    /// <summary>
    /// Class for handling the death of a gameobject. This component communicates directly with
    /// an Ihealth interface if added, but does not require it to function.
    /// </summary>
    public class Death : MonoBehaviour, IDeath
    {
        public IHealth healthInterface;

		// Called when this object dies
		public event Action<Attack> OnDeath;

		private void Awake()
		{
			healthInterface = GetComponent<IHealth>();
		}

		private void OnEnable()
		{
			if(healthInterface != null)
			{
				healthInterface.OnHealthZero += Die;
			}
		}

		private void OnDisable()
		{
			if(healthInterface != null)
			{
				healthInterface.OnHealthZero -= Die;
			}
		}
	
		/// <summary>
		/// Kill the object. By killing the object, we mean disabling it. This method is not called
		/// when calling onDestroy or OnDisable.
		/// 
		/// TODO:
		/// Consider adding calls to this method when the gameobject is disabled or destroyed
		/// outside of this method
		/// </summary>
		public void Die(Attack attack)
		{
			OnDeath?.Invoke(attack);
			this.gameObject.SetActive(false);
		}
	}
}
