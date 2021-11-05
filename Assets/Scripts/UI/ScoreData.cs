using System;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "Create ScoreData", fileName = "ScoreData", order = 0)]
    public class ScoreData : ScriptableObject
    {
        [SerializeField] private int defaultValue;
        
        private int _currentValue;
        
        private ScoreData() => _currentValue = defaultValue;
        
        public Action ScoreChanged { get; set; }

        public override string ToString() => _currentValue.ToString();
        
        public void Add(int value)
        {
            _currentValue += value;
            ScoreChanged?.Invoke();
        }
    }
}
