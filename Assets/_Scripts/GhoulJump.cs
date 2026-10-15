using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class GhoulJump : MonoBehaviour
{
    InputAction jumpAction;
    Rigidbody rigidBody;

    [SerializeField]
    float jumpSpeed = 5f;

    bool isGrounded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        jumpAction.performed += JumpAction_performed;
    }

    private void OnDestroy()
    {
        jumpAction.performed -= JumpAction_performed;
    }

    private void JumpAction_performed(InputAction.CallbackContext obj)
    {
        if (isGrounded)
        {
            rigidBody.linearVelocity = new Vector3(rigidBody.linearVelocity.x, jumpSpeed, rigidBody.linearVelocity.z);
        }
    }

    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
    }

}
