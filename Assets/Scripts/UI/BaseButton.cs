using UnityEngine;

public class BaseButton : MonoBehaviour
{
    private bool _isHaveFlag;

    public void TurnOffButton()
    {
        this.gameObject.SetActive(false);
    }

    public void TurnOnButton()
    {
        this.gameObject.SetActive(true);
    }
}