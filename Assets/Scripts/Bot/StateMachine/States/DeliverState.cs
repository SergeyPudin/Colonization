using UnityEngine;

[RequireComponent(typeof(TargetHandler), typeof(Bot))]
public class DeliverState : State
{
    private TargetHandler _mover;
    private Bot _bot;

    private void Awake()
    {
        _mover = GetComponent<TargetHandler>();
        _bot = GetComponent<Bot>();
    }

    private void OnEnable()
    {
        _mover.SetBaseAsTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_bot.IsBusy && other.TryGetComponent<Base>(out _))
        {
            _bot.SetFree();
            NeedTransit();
        }
    }
}