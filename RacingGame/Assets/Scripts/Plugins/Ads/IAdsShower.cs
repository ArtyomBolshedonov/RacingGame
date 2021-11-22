using System;

namespace Ads
{
    internal interface IAdsShower
    {
        void ShowInterstitial();
        void ShowVideo(Action successShow);
    }
}
