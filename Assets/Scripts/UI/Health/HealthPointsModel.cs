using System;

namespace UI.Health
{
    public class HealthPointsModel
    {
        private HealthPointsModel() { }

        public static HealthPointsModel Instance { get; } = new HealthPointsModel();
        
        public int? CurrentValue { get; private set; }

        public event Action OnHealthChanged;
        public event Action OnDied;

        public void Init(int defaultValue)
        {
            if (CurrentValue == 0) 
                CurrentValue = defaultValue;
        }
        
        public void TakeDamage(int? value)
        {
            CurrentValue -= value;
            OnHealthChanged?.Invoke();

            if (!(CurrentValue <= 0)) return;
            
            CurrentValue = 0;
            OnDied?.Invoke();
        }
    }
}
