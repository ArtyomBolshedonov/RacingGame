using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RacingGame
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _showRewarded;

        public void Init(UnityAction startGame, UnityAction showAd)
        {
            _buttonStart.onClick.AddListener(startGame);
            _showRewarded.onClick.AddListener(showAd);
        }

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }
    }
}
