using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class GhoulController : MonoBehaviour
{
    Animator _animator;
    InputAction _moveAction;

    [SerializeField]
    [Range(0.1f, 10f)]
    float _speed = 2f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        var moveVector = _moveAction.ReadValue<Vector2>();

        if (moveVector.x != 0 || moveVector.y != 0)
        {
            Vector3 vx = moveVector.x * Vector3.right;
            Vector3 vz = moveVector.y * Vector3.forward;

            transform.Translate((vx + vz) * Time.deltaTime * _speed);

            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }
}
