using UnityEngine;

[RequireComponent(typeof(TargetHandler))]
public class PatrolState : State
{
    private Transform[] _wayPoints;
    private TargetHandler _targetHandler;

    private void Awake()
    {
        _targetHandler = GetComponent<TargetHandler>();
    }

    private void OnEnable()
    {
        _targetHandler.SetTarget(_wayPoints[default]);

        _targetHandler.TargetReached += SetNewTarget;
    }

    private void OnDisable()
    {
        _targetHandler.TargetReached -= SetNewTarget;
    }

    private void Update()
    {
        if (_targetHandler.Target.TryGetComponent<Crystal>(out _))
            NeedTransit();
    }

    public void GetWaypoints(Transform[] waypoints)
    {
        _wayPoints = waypoints;
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

        _targetHandler.SetTarget(_wayPoints[nextindex]);
    }
}