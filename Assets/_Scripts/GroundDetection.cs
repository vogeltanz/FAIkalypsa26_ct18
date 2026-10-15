using UnityEngine;
using UnityEngine.Events;

public class GroundDetection : MonoBehaviour
{
    public UnityEvent<bool> onGroundedChanged;
    bool isGrounded = false;

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
        onGroundedChanged.Invoke(isGrounded);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isGrounded)
        {
            isGrounded = true;
            onGroundedChanged.Invoke(isGrounded);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
        onGroundedChanged.Invoke(isGrounded);
    }
}
