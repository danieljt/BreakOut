using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StupidGirlGames.HealthSystem
{
    /// <summary>
    /// Interface for behaviour concerning health
    /// </summary>
    public interface IHealth
    {
        event Action<int> OnHealthChanged;
        event Action OnHealthZero;

        void TakeDamage(int health);
    }
}
