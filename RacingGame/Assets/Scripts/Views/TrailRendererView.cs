using JoostenProductions;
using UnityEngine;

namespace RacingGame
{
    public class TrailRendererView : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trailRenderer;

        private void Start()
        {
            UpdateManager.SubscribeToUpdate(Trail);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Trail);
        }
        private void Trail()
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _trailRenderer.transform.position = position;
        }
    }
}
