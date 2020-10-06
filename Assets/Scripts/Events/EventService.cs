using UnityEngine;
using System;
using Generic;

namespace Singalton
{
    public class EventService : MonoSingletonGeneric<EventService>
    {
        public event Action<int> OnPlayerHit;
        public event Action<int> OnCoinPicked;

        protected override void Awake()
        {
            base.Awake();
        }

        public void FireOnPlayerHit(int amount)
        {
            Debug.Log("FireOnPlayerHit");
            OnPlayerHit?.Invoke(amount);
        }


        public void FireOnCoinPicked(int score)
        {
            Debug.Log("FireOnCoinPicked");
            OnCoinPicked?.Invoke(score);
        }
    }
}
