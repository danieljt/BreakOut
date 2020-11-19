using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using StupidGirlGames.Patterns.Mediator;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// This component allows this gameobject to be saved and loaded.
    /// TODO
    /// - How to we save the object? What can be serialized?
    /// - How do we know if an object in the scene should get the savedata?
    /// - SaveData will come from multiple components. How do we solve this.
    /// </summary>
    public class SaveController : MonoBehaviour
    {
        [Tooltip("The saveData is sent to this mediatorAsset")]
        public SaveDataMediatorAsset mediator;
        public event Action SaveGame;
        private SaveData saveData;
    }
}
