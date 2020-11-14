using System;
using UnityEngine;

namespace StupidGirlGames.Patterns.Mediator
{
    /// <summary>
    /// A mediator asset is an intermediary between a sender and a reciever. Any object
    /// can listen or call the methods in the asset to communicate with other game objects.
    /// This object can be stored as an asset, and we can therefore avoid using the singleton
    /// pattern in these cases.
    /// </summary>
    [CreateAssetMenu(menuName = "Patterns/Mediator/MediatorAsset")]
    public class MediatorAsset : ScriptableObject
    {
        // This event is called when an object calls the notify 
        public event Action OnNotify;

        /// <summary>
        /// call this method to notify all listeners about the event. This method can
        /// be subscribed to by a senders delegate
        /// </summary>
        /// <param name="message"></param>
        public void CallNotify()
		{
            OnNotify?.Invoke();
		}
    }
}
