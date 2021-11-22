using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    internal class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
    {
        private const string _gameId = "4460397";
        private const string _rewardPlace = "Rewarded_Android";
        private const string _interstitialPlace = "Interstitial_Android";

        private bool _isInitialized = false;
        private Action _callbackSuccessShowVideo;

        private void Start()
        {
            Advertisement.Initialize(_gameId);
        }

        public void ShowInterstitial()
        {
            Advertisement.Show(_interstitialPlace);
        }

        public void ShowVideo(Action successShow)
        {
            _callbackSuccessShowVideo = successShow;
            Advertisement.Show(_rewardPlace);
        }

        public void OnUnityAdsReady(string placementId)
        {
            Debug.Log($"Placement ready {placementId}");
            _isInitialized = true;
        }

        public void OnUnityAdsDidError(string message)
        {
            Debug.LogError(message);
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            Debug.Log($"Placement started {placementId}");
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            _callbackSuccessShowVideo?.Invoke();
            _callbackSuccessShowVideo = null;
        }
    }
}
