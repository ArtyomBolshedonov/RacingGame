using UnityEngine.EventSystems;

namespace RacingGame
{
    internal interface IDragHandler
    {
        void OnDrag(PointerEventData eventData);
    }
}
