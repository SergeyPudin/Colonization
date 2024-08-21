using UnityEngine;

[RequireComponent(typeof(TargetHandler), typeof(Bot))]
public class DeliverState : State
{
    private TargetHandler _targetHandler;
    private Bot _bot;

    private void Awake()
    {
        _targetHandler = GetComponent<TargetHandler>();
        _bot = GetComponent<Bot>();
    }

    private void OnEnable()
    {
        _targetHandler.SetBaseAsTarget();       
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