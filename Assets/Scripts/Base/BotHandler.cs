using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotHandler : MonoBehaviour
{
    private ResourceCounter _counter;
    private List<Bot> _ownBots = new();
    private Base _commandCentr;

    private void Start()
    {
        _commandCentr = GetComponent<Base>();

        if (_ownBots != null)
        {
            foreach (var bot in _ownBots)
            {
                SetBaseAsTarget(bot);
            }
        }
    }

    public void SetBot(Bot bot)
    {
        SetBaseAsTarget(bot);
        _ownBots.Add(bot);
    }

    public void AssignCrystal(Crystal targetCrystal)
    {
        DispatchBot(targetCrystal);
    }

    public void AssignFlag()
    {
        StartCoroutine(WaitRequiredamount());
    }

    public void GetCounter(ResourceCounter counter)
    {
        _counter = counter;
    }

    private void SetBaseAsTarget(Bot bot)
    {
        bot.TryGetComponent<TargetHandler>(out TargetHandler targetHandler);
        targetHandler.SetBase(this.transform);
    }

    private void DispatchBot(Crystal crystal)
    {
        if (crystal != null)
        {
            FindClosestBot(out Bot bot, crystal.transform);

            if (bot != null)
            {
                if (bot.TryGetComponent<TargetHandler>(out TargetHandler mover))
                {
                    mover.SetTarget(crystal.transform);
                    bot.SetBusy();
                    crystal.Assign();
                }
            }
        }
    }

    private void FindClosestBot(out Bot closiestBot, Transform target)
    {
        float minValue = float.MaxValue;
        closiestBot = null;

        foreach (var bot in _ownBots)
        {
            if (bot.IsBusy == false)
            {
                float distance = Vector3.Distance(bot.transform.position, target.position);

                if (distance < minValue)
                {
                    minValue = distance;
                    closiestBot = bot;
                }
            }
        }
    }

    private IEnumerator WaitRequiredamount()
    {
            while (_counter.IsAffordBase() == false)
            {
                yield return null;
            }

        BuildBase();
    }

    private void BuildBase()
    {
        if (_commandCentr.Flag != null && _commandCentr.Flag.enabled)
        {
            Transform flagPlace = _commandCentr.Flag.transform;

            FindClosestBot(out Bot bot, flagPlace);

            if (bot != null)
            {
                if (bot.TryGetComponent<TargetHandler>(out TargetHandler mover))
                {
                    bot.SetBusy();
                    mover.SetTarget(flagPlace.transform);
                }
            }

            _commandCentr.Flag.Assign();
        }
    }
}