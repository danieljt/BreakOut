using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StupidGirlGames.Patterns.Mediator
{
	/// <summary>
	/// The run time list can hold objects at runtime. The list is saved as an asset and is perfect for grouping objects
	/// together while avoiding the use of singletons. The class acts as a mediator list between This class is abstract and generic, 
	/// and should be extended with the appropriate class and object.
	/// </summary>
	public abstract class RunTimeList<T> : ScriptableObject
	{
		// Called everytime and object is added
		public event Action<T> OnAdded;

		// Called when the list is empty
		public event Action OnEmpty;

		// called when the an object is removed
		public event Action<T> OnRemoved;

		// This is the list of objects
		protected List<T> objects;

		/// <summary>
		/// Add the newObject to the list if it is not there from before
		/// </summary>
		/// <param name="newObject"></param>
		public void Add(T newObject)
		{
			if(!objects.Contains(newObject))
			{
				objects.Add(newObject);
				OnAdded?.Invoke(newObject);
			}
		}

		/// <summary>
		/// Remove the oldObject from the list if it can be found.
		/// </summary>
		/// <param name="oldObject"></param>
		public void Remove(T oldObject)
		{
			if(objects.Contains(oldObject))
			{
				objects.Remove(oldObject);
				OnRemoved?.Invoke(oldObject);
			}

			if(objects.Count <= 0)
			{
				OnEmpty?.Invoke();
			}
		}
	}
}

