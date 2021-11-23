using UnityEngine;
using UnityEngine.UI;

namespace UI.Score
{
    public class BestScore : MonoBehaviour
    {
        [SerializeField] private Text textComponent;
    
        private const string Key = nameof(BestScore);
        private static int _best;

        public bool TryBeat(int newScore)
        {
            if (newScore > _best)
            {
                _best = newScore;
                PlayerPrefs.SetInt(Key, _best);
            }

            return newScore > _best;
        }
    
        public void UpdateText() => textComponent.text = PlayerPrefs.GetInt(Key, _best).ToString();
    }
}
