using UnityEngine.EventSystems;

namespace RacingGame
{
    internal interface IPointerUpHandler
    {
        void OnPointerUp(PointerEventData eventData);
    }
}
