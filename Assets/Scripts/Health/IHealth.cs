using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using StupidGirlGames.AttackSystem;

namespace StupidGirlGames.HealthSystem
{
    /// <summary>
    /// Interface for behaviour concerning health
    /// </summary>
    public interface IHealth
    {
        event Action<Attack> OnHealthChanged;
        event Action OnHealthZero;

        void TakeDamage(Attack attack);
    }
}
