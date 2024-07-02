using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private CrystalAcceptor _crystalHandler;

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
    }

    private void OnDisable()
    {
        _crystalHandler.CrystalUploaded -= IncriminateCount;
    }

    private void IncriminateCount()
    {
        _count++;
        ValueChanged?.Invoke();
    }
}