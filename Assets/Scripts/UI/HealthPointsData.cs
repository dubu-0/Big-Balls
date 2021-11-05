using System;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "Create HealthPointsData", fileName = "HealthPointsData", order = 0)]
    public class HealthPointsData : ScriptableObject
    {
        [SerializeField] private int defaultValue;
        
        private int _currentValue;
        
        private HealthPointsData() => _currentValue = defaultValue;
        
        public Action HealthChanged { get; set; }

        public override string ToString() => _currentValue.ToString();
        
        public void TakeDamage(int value)
        {
            _currentValue -= value;

            HealthChanged?.Invoke();
            
            if (_currentValue <= 0) 
                Die();
        }

        private void Die() => Debug.LogWarning("You are dead");
    }
}
