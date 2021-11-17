using UnityEngine;

namespace RacingGame
{
    internal class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private Transform _placeForUi;
        [SerializeField]
        private float _gameSpeed;

        private MainController _mainController;

        private void Awake()
        {
            var profilePlayer = new ProfilePlayer(_gameSpeed);
            profilePlayer.CurrentState.Value = GameState.Start;
            _mainController = new MainController(_placeForUi, profilePlayer);
        }

        protected void OnDestroy()
        {
            _mainController?.Dispose();
        }
    }
}
