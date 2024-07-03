using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BotButtonHandler : MonoBehaviour
{
    [SerializeField] private BotCreator _creator;

    private Button _button;

    public event UnityAction<int> BuyBot;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (_button != null)
            _button.onClick.AddListener(TryBuyBot);
    }

    private void OnDisable()
    {
        if (_button != null)
            _button.onClick.RemoveListener(TryBuyBot);
    }

    private void TryBuyBot()
    {
            BuyBot?.Invoke(_creator.Price);
    }
}