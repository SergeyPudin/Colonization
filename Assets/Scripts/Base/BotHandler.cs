using UnityEngine;

public class BotHandler : MonoBehaviour
{
    [SerializeField] private Bot[] _defaultBots;
    [SerializeField] private Counter _counter;

    private void Awake()
    {
        foreach (var bot in _defaultBots)
        {
            bot.TryGetComponent<TargetHandler>(out TargetHandler mover);
            mover.SetBase(this.transform);
        }
    }

    public void AssignCrystal(Crystal targetCrystal)
    {
        DispatchBot(targetCrystal);
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

        foreach (var bot in _defaultBots)
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
}