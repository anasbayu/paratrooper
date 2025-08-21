using UnityEngine;
using UnityEngine.InputSystem;

public class InputHelper : MonoBehaviour
{

    public void OnAttack(InputAction.CallbackContext context)
    {
        // Call Attack() every frame while button is held (performed)
        if (context.started)
        {
            PlayerAttack.Instance.Attack();
        }

        if (context.canceled)
        {
            PlayerAttack.Instance.StopAttack();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            PlayerMovement.Instance.RotateTurret(moveInput);
        }
    }
}
