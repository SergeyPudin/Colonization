using UnityEngine;
using Zenject;

public class GameplaySceneInstaler : MonoInstaller
{
    [SerializeField] private Bot[] _defaultBots;
    [SerializeField] private Bot _botPrefab;

    public override void InstallBindings()
    {
        InstallBot();
        InstallBotFactory();
    }

    private void InstallBot()
    {
        Container.Bind<Bot[]>().FromInstance(_defaultBots);
    }

    private void InstallBotFactory()
    {
        Container.BindFactory<Bot, BotFactory>().FromComponentInNewPrefab(_botPrefab);
    }
}