using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StupidGirlGames.Health
{
    /// <summary>
    /// Interface for behaviour concerning health
    /// </summary>
    public interface IHealth
    {
        event Action<int> OnHealthChanged;
        event Action OnHealthZero;

        void ChangeHealth(int health);
    }
}
