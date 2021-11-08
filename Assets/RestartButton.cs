using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button button;
    
    public void RestartCurrentSceneOnClick() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
