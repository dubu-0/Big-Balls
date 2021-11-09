using System;
using UI.Health;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    [SerializeField] private BoxCollider2D cover;
    
    private Action _showButton;
    
    private void Awake()
    {
        _showButton = () => gameObject.SetActive(true);
        HealthPointsModel.Instance.OnDied += _showButton;
        HealthPointsModel.Instance.OnDied += DisallowUserClicks;
        cover.enabled = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        HealthPointsModel.Instance.OnDied -= _showButton;
        HealthPointsModel.Instance.OnDied -= DisallowUserClicks;
    }

    private void DisallowUserClicks() => cover.enabled = true;
    
    public void RestartCurrentSceneOnClick() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
