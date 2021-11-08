using System;
using UI.Health;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    private Action _activateGameObject;
    
    private void Awake()
    {
        _activateGameObject = () => gameObject.SetActive(true);
        HealthPointsModel.Instance.OnDied += _activateGameObject;
    }

    private void OnDestroy()
    {
        HealthPointsModel.Instance.OnDied -= _activateGameObject;
    }

    public void RestartCurrentSceneOnClick() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
