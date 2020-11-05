using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using StupidGirlGames.AttackSystem;

namespace StupidGirlGames.HealthSystem
{
    /// <summary>
    /// Interface for behaviours concerning health
    /// </summary>
    public interface IHealth
    {
        event Action<Attack> OnHealthChanged;
        event Action<Attack> OnHealthZero;

        void LoseHealth(Attack attack);
        void GainHealth(Attack attack);
    }
}
