using TMPro;
using UnityEngine;

public class UIViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ResourceCounter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += ShowNewValue;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ShowNewValue;
    }

    private void ShowNewValue()
    {
        _text.text = _counter.Count.ToString();
    }
}
