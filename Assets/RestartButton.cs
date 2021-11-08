using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    public void RestartCurrentSceneOnClick() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
