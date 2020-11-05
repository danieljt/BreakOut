using System;
using UnityEngine;

namespace StupidGirlGames.Patterns.Mediator
{
    /// <summary>
    /// A mediator asset is an intermediary between a sender and a reciever. Any object
    /// can listen or call the methods in the asset to communicate with other game objects.
    /// This object can be stored as an asset, and we can therefore avoid using the singleton
    /// pattern in these cases. This class is abstract. Inherit from this class to allow
    /// specific objects
    /// </summary>
    public abstract class MediatorAsset<T> : ScriptableObject
    {
        // This event is called when an object calls the notify 
        public event Action<T> OnNotify;

        /// <summary>
        /// call this method to notify all listeners about the event. This method can
        /// be subscribed to by a senders delegate
        /// </summary>
        /// <param name="message"></param>
        public void Notify(T message)
		{
            OnNotify?.Invoke(message);
		}
    }
}
