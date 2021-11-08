using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ContinueButton : MonoBehaviour
{
    public void DisableRootCanvasOnClick() => transform.root.gameObject.SetActive(false);
    public void UnpauseOnClick(float timeScale) => Time.timeScale = timeScale;
}
