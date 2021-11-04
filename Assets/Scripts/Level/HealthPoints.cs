using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    public class HealthPoints : MonoBehaviour
    {
        [SerializeField] private Text textComponent;
        [SerializeField] private int healthPoints;

        private void Start()
        {
            UpdateText();
        }

        public void TakeDamage(int value)
        {
            healthPoints -= value;
            UpdateText();

            if (healthPoints <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("GameOver!");
        }
    
        private void UpdateText() => textComponent.text = healthPoints.ToString();
    }
}
