using JoostenProductions;
using UnityEngine;

namespace RacingGame
{
    internal class SwipeInputView : BaseInputView
    {
        private Vector2 _tapPosition;
        private Vector2 _swipeDelta;

        private new float _speed = 0.0f;
        private readonly float _deadzone = 10;
        private readonly float _slowUpPerSecond = 0.5f;
        private bool _isSwiping;
        private bool _isMobile;

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            _isMobile = Application.isMobilePlatform;
            UpdateManager.SubscribeToUpdate(OnUpdate);
        }

        private void OnUpdate()
        {
            GetSwipeStarting();
            CheckSwipe();
            Move();
            Slowdown();
        }

        private void GetSwipeStarting()
        {
            if (!_isMobile)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _isSwiping = true;
                    _tapPosition = Input.mousePosition;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    ResetSwipe();
                }
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        _isSwiping = true;
                        _tapPosition = Input.GetTouch(0).position;
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        ResetSwipe();
                    }
                }
            }
        }

        private void CheckSwipe()
        {
            _swipeDelta = Vector2.zero;
            if (_isSwiping)
            {
                if (!_isMobile && Input.GetMouseButton(0))
                    _swipeDelta = (Vector2)Input.mousePosition - _tapPosition;
                else if (Input.touchCount > 0)
                    _swipeDelta = Input.GetTouch(0).position - _tapPosition;
            }
            if(_swipeDelta.sqrMagnitude > _deadzone)
            {
                if (Mathf.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
                        AddAcceleration(_swipeDelta.x/100);
                ResetSwipe();
            }
        }

        private void ResetSwipe()
        {
            _isSwiping = false;
            _tapPosition = Vector2.zero;
            _swipeDelta = Vector2.zero;
        }

        private void AddAcceleration(float acc)
        {
            _speed = Mathf.Clamp(_speed + acc, -1f, 1f);
        }

        private void Slowdown()
        {
            var sgn = Mathf.Sign(_speed);
            _speed = Mathf.Clamp01(Mathf.Abs(_speed) - _slowUpPerSecond * Time.deltaTime) * sgn;
        }

        private void Move()
        {
            if (_speed < 0)
                OnLeftMove(_speed);
            else
                OnRightMove(_speed);
        }

        void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(OnUpdate);
        }
    }
}
