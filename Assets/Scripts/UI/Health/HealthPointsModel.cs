using System;
using UnityEngine;

namespace UI.Health
{
    public class HealthPointsModel
    {
        private HealthPointsModel() { }

        public static HealthPointsModel Instance { get; } = new HealthPointsModel();
        
        public int CurrentValue { get; private set; }

        public event Action OnHealthChanged;

        public void Init(int defaultValue)
        {
            if (CurrentValue == 0) 
                CurrentValue = defaultValue;
        }
        
        public void TakeDamage(int value)
        {
            CurrentValue -= value;
            OnHealthChanged?.Invoke();

            if (CurrentValue <= 0) 
                Die();
        }

        private void Die() => Debug.LogWarning("You are dead");
    }
}
