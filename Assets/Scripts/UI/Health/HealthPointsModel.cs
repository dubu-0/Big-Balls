using System;
using UnityEngine;

namespace UI.Health
{
    public static class HealthPointsModel
    {
        public static int CurrentValue { get; private set; }

        public static event Action OnHealthChanged;

        public static void TakeDamage(int value)
        {
            CurrentValue -= value;

            OnHealthChanged?.Invoke();
            
            if (CurrentValue <= 0) 
                Die();
        }

        private static void Die() => Debug.LogWarning("You are dead");
    }
}
