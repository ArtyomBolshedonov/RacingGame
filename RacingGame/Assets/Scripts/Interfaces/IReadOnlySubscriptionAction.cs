using System;

namespace RacingGame
{
    internal interface IReadOnlySubscriptionAction
    {
        void SubscribeOnChange(Action subscriptionAction);
        void UnSubscriptionOnChange(Action unsubscriptionAction);
    }
}
