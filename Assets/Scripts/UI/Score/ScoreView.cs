using UnityEngine;
using UnityEngine.UI;

namespace UI.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text textComponent;

        private void OnEnable() => ScoreModel.Instance.OnScoreChanged += UpdateText;
        private void OnDisable() => ScoreModel.Instance.OnScoreChanged -= UpdateText;
        private void UpdateText() => textComponent.text = ScoreModel.Instance.CurrentValue.ToString();
    }
}