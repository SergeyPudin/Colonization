using UnityEngine;

public class Bot : MonoBehaviour
{
    private bool _isBusy;

    public bool IsBusy => _isBusy;
    
    private void Start()
    {     
        _isBusy = false;
    }

    public void SetBusy()
    {
        _isBusy = true;
    }

    public void SetFree()
    {
        _isBusy = false;
    }
}