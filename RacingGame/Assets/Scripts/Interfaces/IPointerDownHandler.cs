using UnityEngine.EventSystems;

namespace RacingGame
{
    internal interface IPointerDownHandler
    {
        void OnPointerDown(PointerEventData eventData);
    }
}
