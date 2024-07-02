using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Transform target)
    {
        Vector3 targetPosition = Vector3.MoveTowards(transform.position, target.transform.position, _moveSpeed * Time.fixedDeltaTime);
        targetPosition.y = transform.position.y;

        transform.LookAt(targetPosition);
        _rigidbody.MovePosition(targetPosition);
    }
}
