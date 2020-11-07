using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// A win condition is a behaviour that has a condition. Once the condition is
    /// met,  win condition send an event that it has been met
    /// </summary>
    public class WinCondition : MonoBehaviour
    {
        public event Action ConditionMet;
    }
}
