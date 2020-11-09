using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.Patterns.Mediator
{
    /// <summary>
    /// An int mediator asset defines an interidiary between senders and listeners where
    /// the message is an int.
    /// </summary>
    [CreateAssetMenu(menuName = "Patterns/Mediator/IntMediatorAsset")]
    public class IntMediatorAsset : AbstractMediatorAsset<int>
    {

    }
}
