using UnityEngine;
using System;

namespace StupidGirlGames.HealthSystem
{
    /// <summary>
    /// Common interface for all objects that can die. When an object dies, we get the
    /// gameobject that did the kill.
    /// </summary>
    public interface IDeath
    {
        event Action<GameObject> OnDeath;

        void Die(GameObject killer);
    }
}
