using System;

namespace UI.Score
{
    public class ScoreModel
    {
        private ScoreModel() { }

        public static ScoreModel Instance { get; } = new ScoreModel();
        
        public int CurrentValue { get; private set; }

        public event Action OnScoreChanged;

        public void Add(int value)
        {
            CurrentValue += value;
            OnScoreChanged?.Invoke();
        }

        public void ToDefault()
        {
            CurrentValue = 0;
            OnScoreChanged?.Invoke();
        }
    }
}
