using UnityEngine;
using UnityEngine.UI;

namespace UI.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text textComponent;

        private void OnEnable()
        {
            ScoreModel.OnScoreChanged += UpdateText;
        }

        private void OnDisable()
        {
            ScoreModel.OnScoreChanged -= UpdateText;
        }

        private void UpdateText() => textComponent.text = ScoreModel.CurrentValue.ToString();
    }
}