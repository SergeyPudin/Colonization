using UnityEngine;

public class BotCreator : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private Bot _prefab;
    [SerializeField] private BotButtonHandler _buttonHandler;

    private void OnEnable()
    {
        _buttonHandler.BuyBot += CreateBot;
    }

    public int Price => _price;

    private void CreateBot(int _)
    {
        Debug.Log("Creating bot");
        //Bot bot = Instantiate(_prefab);
    }
}
