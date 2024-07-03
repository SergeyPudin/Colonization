using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BotButton : MonoBehaviour
{
       private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }
}