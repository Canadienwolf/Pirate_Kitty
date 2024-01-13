using UnityEngine;
using UnityEngine.InputSystem;

namespace Blobbers.Player
{
    public class PlayerControllerInput : MonoBehaviour
    {
        public Vector3 InputMove {  get; protected set; }
        public bool InputRun { get; protected set; }
        public bool InputJump { get; protected set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed && context.phase != InputActionPhase.Canceled) return;

            Vector2 _dir = context.ReadValue<Vector2>();
            InputMove = new Vector3(_dir.x, 0, _dir.y);
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            if(context.performed)
                InputRun = true;
            else if (context.canceled)
                InputRun= false;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                InputJump = true;
            else if (context.canceled)
                InputJump = false;
        }
    }
}
