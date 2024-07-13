using UnityEngine;
using Zenject;

public class BotCreator : MonoBehaviour
{
    [SerializeField] private int _price;
    //[SerializeField] private Bot _prefab;
    [SerializeField] private BotButtonHandler _buttonHandler;
    [SerializeField] private Transform _spawnPoint;

    [Inject]
    private BotFactory _botFactory;

    private void OnEnable()
    {
        _buttonHandler.BuyBot += CreateBot;
    }

    public int Price => _price;

    private void CreateBot(int _)
    {
        Debug.Log("Creating bot");
        Bot bot = _botFactory.Create();
        bot.transform.position = _spawnPoint.position;
    }
}
