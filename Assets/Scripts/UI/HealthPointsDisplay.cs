using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthPointsDisplay : MonoBehaviour
    {
        [SerializeField] private HealthPointsData healthPointsData;
        [SerializeField] private Text textComponent;

        private void OnEnable() => healthPointsData.HealthChanged += OnHealthChanged;
        private void OnDisable() => healthPointsData.HealthChanged -= OnHealthChanged;
        private void OnHealthChanged() => textComponent.text = healthPointsData.ToString();
    }
}