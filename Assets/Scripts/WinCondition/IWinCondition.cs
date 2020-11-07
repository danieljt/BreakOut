using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// Common interface for win conditions. Win conditions can be quite different, so it is easier
    /// to keep to uing an interface.
    /// </summary>
    public interface IWinCondition
    {
        event Action OnWinConditionSatisfied;
    }
}
