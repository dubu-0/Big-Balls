using System;

namespace UI.Score
{
    public static class ScoreModel
    {
        public static int CurrentValue { get; private set; }

        public static event Action OnScoreChanged;

        public static void Add(int value)
        {
            CurrentValue += value;
            OnScoreChanged?.Invoke();
        }
    }
}
