using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace KatsisMiniGames.Engine.Game
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
        }

        private bool _isClicked;
        private Vector2 _lastDragPos = Vector2.zero;
        public UnityEvent<bool> OnClick { get; } = new();
        public UnityEvent<Vector2> OnDrag { get; } = new();

        public void OnClickInternal(InputAction.CallbackContext value)
        {
            if (value.phase == InputActionPhase.Started)
            {
                _isClicked = true;
                _lastDragPos = Mouse.current.position.ReadValue();
                OnClick.Invoke(true);
            }
            else if (value.phase == InputActionPhase.Canceled)
            {
                _isClicked = false;
                OnClick.Invoke(false);
            }
        }

        public void OnMouseMoveInternal(InputAction.CallbackContext _)
        {
            if (_isClicked)
            {
                var delta = Mouse.current.position.ReadValue() - _lastDragPos;

                if (delta.magnitude != 0f)
                {
                    OnDrag.Invoke(delta);
                }
            }
        }
    }
}
