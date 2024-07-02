using UnityEngine;

[RequireComponent(typeof(TargetHandler))]
public class PatrolState : State
{
    [SerializeField] private Transform[] _wayPoints;

    private TargetHandler _mover;

    private void Awake()
    {
        _mover = GetComponent<TargetHandler>();
    }

    private void OnEnable()
    {
        _mover.SetTarget(_wayPoints[default]);

        _mover.TargetReached += SetNewTarget;
    }

    private void OnDisable()
    {
        _mover.TargetReached -= SetNewTarget;
    }

    private void Update()
    {
        if (_mover.Target.TryGetComponent<Crystal>(out _))
            NeedTransit();
    }
    public void SetNewTarget(Transform target)
    {
        int number = default;

        for (int i = 0; i < _wayPoints.Length; ++i)
        {
            if (target == _wayPoints[i])
                number = i;
        }

        int nextindex = (number + 1) % _wayPoints.Length;

        _mover.SetTarget(_wayPoints[nextindex]);
    }
}