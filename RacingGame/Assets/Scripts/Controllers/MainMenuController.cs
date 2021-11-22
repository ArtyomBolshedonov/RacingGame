using UnityEngine;
using Ads;

namespace RacingGame
{
    internal sealed class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/MainMenu" };
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        private readonly IAdsShower _adsShower;

        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, IAdsShower adsShower)
        {
            _profilePlayer = profilePlayer;
            _adsShower = adsShower;
            _view = LoadView(placeForUi);
            _view.Init(StartGame, ShowRewarded);
        }

        private void ShowRewarded()
        {
            _adsShower.ShowVideo(()=> Debug.Log("Reward"));
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
        }
    }
}
