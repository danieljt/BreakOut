using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using StupidGirlGames.Patterns.Mediator;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// A player manager is responsible for the player. This is a good place to store lives and other values
    /// that are useful. This manager is also makes it easier to have multiple players and tweak
    /// their interactions with the gam itself.
    /// </summary>
    public class PlayerManager : MonoBehaviour
    {
        [Tooltip("The players communicate to the manager through this mediator")]
        public GameObjectMediatorAsset playerMediator;

        [Tooltip("This manager communicates to this mediator when all players are dead")]
        public MediatorAsset allPlayersDied;

        // This event is called when all players have died.
        public event Action OnAllPlayersDied;

        // This is the list containing the player gameObjects.
        private List<GameObject> players = new List<GameObject>();

        // This is the list of players
        public List<GameObject> Players
		{
			get { return players; }
			set { players = value; }
		}

        /// <summary>
        /// When a player dies, this method is called. The game can consist of multiple players, and each player can have
        /// an effect on the game when they die. When both players die, the manager notifies interested
        /// listeners.
        /// </summary>
        /// <param name="player"></param>
        private void PlayerDied(GameObject player)
		{
            if(players.Contains(player))
			{
                players.Remove(player);

                if(Players.Count <= 0)
				{
                    OnAllPlayersDied?.Invoke();
				}
			}
		}

		private void OnEnable()
		{
            if (allPlayersDied != null)
            {
                OnAllPlayersDied += allPlayersDied.CallNotify;
            }

            if(playerMediator != null)
			{
                playerMediator.Notify += PlayerDied;
			}
		}

		private void OnDisable()
		{
            if (allPlayersDied != null)
            {
                OnAllPlayersDied -= allPlayersDied.CallNotify;
            }

            if(playerMediator != null)
			{
                playerMediator.Notify -= PlayerDied;
			}
        }
	}
}
