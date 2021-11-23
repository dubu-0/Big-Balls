using System;
using UI.Health;
using UI.Score;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D cover;
        [SerializeField] private BestScore bestScore;
    
        private Action _showButton;

        private void Awake()
        {
            _showButton = () => gameObject.SetActive(true);
            HealthPointsModel.Instance.OnDied += _showButton;
            HealthPointsModel.Instance.OnDied += DisallowUserClicks;
        }

        private void OnEnable()
        {
            bestScore.TryBeat(ScoreModel.Instance.CurrentValue);
            bestScore.UpdateText();
        }

        private void Start()
        {
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
}
