using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class BotButton : MonoBehaviour
{
    [SerializeField] private ResourceCounter _resourceCounter; 

    private Button _button;
    private BotSpawner _botSpawner;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ButtonClicked);
    }

    public void TurnOnButton(BotSpawner botSpawner)
    {
        _botSpawner = botSpawner;

        this.gameObject.SetActive(true);
    }

    public void TurnOffButton()
    {
        _botSpawner = null;

        this.gameObject.SetActive(false);
    }

    private void ButtonClicked()
    {
        if (_botSpawner != null && _resourceCounter.IsAffordBot()) 
            _botSpawner.CreateBot();
    }
}