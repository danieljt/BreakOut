using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using StupidGirlGames.AttackSystem;

namespace StupidGirlGames.HealthSystem
{
    /// <summary>
    /// Common interface for all objects that can die. 
    /// </summary>
    public interface IDeath
    {
        event Action<Attack> OnDeath;

        void Die();
    }
}
