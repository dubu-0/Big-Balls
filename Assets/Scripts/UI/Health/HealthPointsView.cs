using UnityEngine;
using UnityEngine.UI;

namespace UI.Health
{
    public class HealthPointsView : MonoBehaviour
    {
        [SerializeField] private Text textComponent;

        private void OnEnable()
        {
            HealthPointsModel.OnHealthChanged += UpdateText;
        }

        private void OnDisable()
        {
            HealthPointsModel.OnHealthChanged -= UpdateText;
        }

        private void UpdateText() => textComponent.text = HealthPointsModel.CurrentValue.ToString();
    }
}