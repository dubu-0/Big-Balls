using UnityEngine;
using UnityEngine.UI;

namespace UI.Health
{
    public class HealthPointsView : MonoBehaviour
    {
        [SerializeField] private Text textComponent;

        private void Awake() => HealthPointsModel.Instance.Init(int.Parse(textComponent.text));
        private void OnEnable() => HealthPointsModel.Instance.OnHealthChanged += UpdateText;
        private void OnDisable() => HealthPointsModel.Instance.OnHealthChanged -= UpdateText;
        private void UpdateText() => textComponent.text = HealthPointsModel.Instance.CurrentValue.ToString();
    }
}