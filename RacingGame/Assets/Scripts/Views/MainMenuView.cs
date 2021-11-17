using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RacingGame
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button _buttonStart;

        public void Init(UnityAction startGame)
        {
            _buttonStart.onClick.AddListener(startGame);
        }

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }
    }
}
