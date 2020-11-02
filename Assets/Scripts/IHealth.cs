using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Interface for behaviour concerning health
/// </summary>
public interface IHealth
{
    event Action OnHealthChanged;
    event Action OnHealthZero;

    void ChangeHealth();
}
