using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private ScoreData scoreData;
        [SerializeField] private Text textComponent;
        
        private void OnEnable() => scoreData.ScoreChanged += OnScoreChanged;
        private void Start() => scoreData.SetDefaultValue();
        private void OnDisable() => scoreData.ScoreChanged -= OnScoreChanged;
        private void OnScoreChanged() => textComponent.text = scoreData.ToString();
    }
}