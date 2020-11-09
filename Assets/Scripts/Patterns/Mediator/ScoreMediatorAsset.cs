using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StupidGirlGames.ScoreSystem;

namespace StupidGirlGames.Patterns.Mediator
{
    /// <summary>
    /// A score mediator defines a intermidiary between a score giver and a listener.
    /// </summary>
    [CreateAssetMenu(menuName = "Patterns/Mediator/ScoreMediatorAsset")]
    public class ScoreMediatorAsset : AbstractMediatorAsset<Score>
    {

    }
}
