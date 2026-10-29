using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GhoulAI : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    float detectionRange = 10f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void CheckPlayerVisibility(GameObject player)
    {
        if (player != null)
        {
            Vector3 originPosition = transform.position + transform.up * 2f + transform.forward * 1f;
            Vector3 playerPosition = player.transform.position + player.transform.up * 2f;

            Vector3 direction = (playerPosition - originPosition).normalized;
            Ray ray = new Ray(originPosition, direction);
            RaycastHit hit;

            Physics.Raycast(ray, out hit, detectionRange, ~LayerMask.GetMask("Ignore Raycast"));
            Debug.DrawRay(ray.origin, ray.direction * detectionRange, Color.red, 0.5f);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                animator.SetBool("PlayerIsVisible", true);
            }
            else
            {
                animator.SetBool("PlayerIsVisible", false);
            }

            float playerDistance = Vector3.Distance(transform.position, player.transform.position);
            animator.SetFloat("PlayerDistance", playerDistance);
        }
        else
        {
            animator.SetBool("PlayerIsVisible", false);
        }
    }
}
