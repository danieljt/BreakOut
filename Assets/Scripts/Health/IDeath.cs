using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StupidGirlGames.HealthSystem
{
    /// <summary>
    /// Common interface for all objects that can die. 
    /// </summary>
    public interface IDeath
    {
        event Action OnDeath;

        void Die();
    }
}
