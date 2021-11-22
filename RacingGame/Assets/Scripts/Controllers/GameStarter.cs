using UnityEngine;
using Ads;
using Analytic;

namespace RacingGame
{
    internal class GameStarter : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUi;
        [SerializeField] private UnityAdsTools _ads;
        [SerializeField] private float _gameSpeed;

        private MainController _mainController;

        private void Awake()
        {
            var analitics = new UnityAnalyticTools();
            var profilePlayer = new ProfilePlayer(_gameSpeed);
            profilePlayer.CurrentState.Value = GameState.Start;
            _mainController = new MainController(_placeForUi, profilePlayer, _ads, analitics);
        }

        protected void OnDestroy()
        {
            _mainController?.Dispose();
        }
    }
}
