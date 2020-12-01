using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.Patterns.Singleton
{
    /// <summary>
    /// Defines a singleton monobehaviour. A singleton must be used carefully and sparingly as it violates 
	/// the SOLID principal. It can couples code, and can also cause race conditions. It does not work with multithreaded code either. 
	/// If used carefully, it can provide a global access point for code and in some cases simplify development. But use carefully
	/// You have been warned...
    /// </summary>
    public class Singleton<T> : MonoBehaviour where T:Singleton<T>
    {
		/// <summary>
		/// Get or set the instance. The set can only be used within the class itself
		/// </summary>
		public static T Instance { get; private set; }

		/// <summary>
		/// returns true if this singleton is already instantiated, false if not.
		/// </summary>
		public static bool IsInstantiated => Instance != null;

		/// <summary>
		/// This method alows for the instantiation of a singleton from without the class scope. An instance is only
		/// created if the static instance variable is null.
		/// </summary>
		public void Instantiate()
		{
			if(Instance == null)
			{
				Instance = (T)this;
			}
		}

		protected virtual void Awake()
		{
			Instantiate();
		}

		/// <summary>
		/// When destroying the singleton, we set it's instance to null. It can then be garbage collected, and
		/// a new instance can be set later.
		/// </summary>
		protected virtual void OnDestroy()
		{
			if(Instance == this)
			{
				Instance = null;
			}
		}
	}
}
