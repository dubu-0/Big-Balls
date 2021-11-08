using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button button;
    
    private const string Play = nameof(Play);
    private const string Paused = nameof(Paused);
    private const string Unpaused = nameof(Unpaused);

    private Text _buttonTextComponent;
    
    private void Start()
    {
        _buttonTextComponent = button.GetComponentInChildren<Text>();
        InitButton();
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
        _buttonTextComponent.text = Paused;
    }

    private void Unpause()
    {
        Time.timeScale = 1;
        _buttonTextComponent.text = Unpaused;
    }
}
