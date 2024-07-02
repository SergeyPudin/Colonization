using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover))]
public class TargetHandler : MonoBehaviour
{
    [SerializeField] private float _distanceThreshold = 0.5f;

    private Mover _mover;
    private Transform _target;
    private Transform _base;

    public Transform Target => _target;

    public event UnityAction<Transform> TargetReached;

    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        _mover.Move(_target);
    }

    private void Update()
    {
        if (_target == null)
            return;

        if (Vector3.Distance(transform.position, _target.transform.position) <= _distanceThreshold)
            TargetReached?.Invoke(_target);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    public void SetBase(Transform CommandCentr)
    {
        _base = CommandCentr;
    }

    public void SetBaseAsTarget()
    {
        if (_base != null)
            _target = _base;
    }
}