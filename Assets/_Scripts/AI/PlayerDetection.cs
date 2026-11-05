using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{
    public UnityEvent<GameObject> onPlayerDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            onPlayerDetected.Invoke(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            onPlayerDetected.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            onPlayerDetected.Invoke(null);
    }
}
