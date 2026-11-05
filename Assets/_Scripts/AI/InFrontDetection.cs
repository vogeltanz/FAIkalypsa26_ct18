using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InFrontDetection : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    float detectionRange = 2f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 originPosition = transform.position + transform.up * 2f + transform.forward * 0.75f;
        Vector3 direction = transform.forward;

        Ray ray = new Ray(originPosition, direction);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, detectionRange, ~LayerMask.GetMask("Ignore Raycast"));
        Debug.DrawRay(ray.origin, ray.direction * detectionRange, Color.blue, 0.5f);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            animator.SetBool("InFront", true);
        }
        else
        {
            animator.SetBool("InFront", false);
        }
    }
}
