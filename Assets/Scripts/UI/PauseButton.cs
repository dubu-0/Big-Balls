using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private BoxCollider2D cover;
    
        private const string Play = nameof(Play);
        private const string Paused = nameof(Paused);
        private const string Unpaused = nameof(Unpaused);

        private Text _buttonTextComponent;
    
        private void Start()
        {
            _buttonTextComponent = button.GetComponentInChildren<Text>();
            InitButton();
            cover.enabled = false;
        }
    
        public void SwitchGameStateOnClick()
        {
            switch (_buttonTextComponent.text)
            {
                case Play:
                    Unpause();
                    break;
                case Unpaused:
                    Pause();
                    break;
                case Paused:
                    Unpause();
                    break;
            }
        }

        private void InitButton()
        {
            _buttonTextComponent.text = Play;
            Time.timeScale = 0;
        }
    
        private void Pause()
        {
            Time.timeScale = 0;
            cover.enabled = true;
            _buttonTextComponent.text = Paused;
        }

        private void Unpause()
        {
            Time.timeScale = 1;
            cover.enabled = false;
            _buttonTextComponent.text = Unpaused;
        }
    }
}
