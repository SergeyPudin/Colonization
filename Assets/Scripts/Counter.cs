using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private CrystalAcceptor _crystalHandler;
    [SerializeField] private BotButtonHandler _buttonHandler;

    private int _count;

    public event UnityAction ValueChanged;

    public int Count => _count;

    private void Start()
    {
        _count = 0;

        ValueChanged?.Invoke();
    }
    private void OnEnable()
    {
        _crystalHandler.CrystalUploaded += IncriminateCount;
        _buttonHandler.BuyBot += SpendCrystal;
    }

    private void OnDisable()
    {
        _crystalHandler.CrystalUploaded -= IncriminateCount;
    }

    public void SpendCrystal(int price)
    {
        if (_count < price)
        {
            return;
        }
        else
        {
            _count -= price;
            ValueChanged?.Invoke();
        }
    }

    private void IncriminateCount()
    {
        _count++;
        ValueChanged?.Invoke();
    }
}