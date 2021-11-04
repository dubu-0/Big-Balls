using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Text textComponent;
        [SerializeField] private int score;
    
        private void Start()
        {
            UpdateText();
        }

        public void Add(int value)
        {
            score += value;
            UpdateText();
        }
    
        private void UpdateText() => textComponent.text = score.ToString();
    }
}
