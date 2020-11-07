using StupidGirlGames.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// A timer defines a countdown from a number to zero. It starts upon creation and
    /// calls an event when the time runs out
    /// </summary>
    public class Timer : MonoBehaviour
    {
        [Tooltip("The time this timer counts down from")]
        public float time;

        [Tooltip("The mediator this timer communicates with")]
        public IntMediatorAsset mediator;

        // Called every tick
        public event Action<int> OnCount;

        // Called when the timer is finished
        public event Action OnTimerFinished;

        private Coroutine timer;
        private float counter;

		private void Awake()
		{
            counter = time;
		}

		private void OnEnable()
		{
			if(mediator != null)
			{
                OnCount += mediator.Notify;
			}
		}

		private void OnDisable()
		{
			if(mediator != null)
			{
                OnCount -= mediator.Notify;
			}
		}
		private void Start()
		{
            StartTimer();
		}

		private void StartTimer()
		{
            timer = StartCoroutine(TimerCountDown());
		}

        /// <summary>
        /// Coroutine for the counter. Calls the OnCount event each tick and the the ontimerfinished
        /// when the countdown reaches zero.
        /// </summary>
        /// <returns></returns>
        private IEnumerator TimerCountDown()
		{
            counter -= Time.deltaTime;
            OnCount?.Invoke(Mathf.RoundToInt(counter));

            if(counter <= 0)
			{
                OnTimerFinished?.Invoke();
                yield break;
			}

            yield return null;
		}
    }
}
