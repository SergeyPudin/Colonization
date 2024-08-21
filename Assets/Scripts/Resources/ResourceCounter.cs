using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private int _botPrice;
    [SerializeField] private int _basePrice;
    [SerializeField] private int _startCount;

    private List<CrystalAcceptor> _crystalAcceptors = new();
    private int _count;

    public event UnityAction ValueChanged;

    public int Count => _count;

    private void Start()
    {
        _count = _startCount;   

        ValueChanged?.Invoke();
    }

    private void OnDisable()
    {
        if (_crystalAcceptors != null)
        {
            foreach (var crystalAcceptor in _crystalAcceptors)
            {
                crystalAcceptor.CrystalUploaded -= IncrementCount;
            }
        }
    }

    public void AddCrystalAcceptor(CrystalAcceptor crystalAcceptor)
    {
        _crystalAcceptors.Add(crystalAcceptor);
        crystalAcceptor.CrystalUploaded += IncrementCount;
    }

    public bool IsAffordBot()
    {
        return IsBaseAffordable(_botPrice);
    }

    public bool IsAffordBase()
    {
        return IsBaseAffordable(_basePrice);
    }

    private bool IsBaseAffordable(int cost)
    {
        if (_count >= cost)
        {
            _count -= cost;
            ValueChanged?.Invoke();
            return true;
        }
        return false;
    }

    private void IncrementCount()
    {
        _count++;
        ValueChanged?.Invoke();
    }
}