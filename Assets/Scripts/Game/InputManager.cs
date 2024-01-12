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

        public UnityEvent OnClick { get; } = new();

        public void OnClickInternal(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                OnClick.Invoke();
            }
        }
    }
}
