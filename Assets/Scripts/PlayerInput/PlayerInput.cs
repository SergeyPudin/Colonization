using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private LayerMask _raycastLayer;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;
    [SerializeField] private EventSystem _eventSystem;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUIElement())
            {
                return;
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _raycastLayer))
            {
                _button.gameObject.SetActive(true);

                hit.collider.gameObject.TryGetComponent<BotHandler>(out BotHandler botHandler);

            }
            else
            {
                _button.gameObject.SetActive(false);
            }
        }
    }

    private bool IsPointerOverUIElement()
    {
        PointerEventData eventData = new PointerEventData(_eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        _graphicRaycaster.Raycast(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == _button.gameObject)
            {
                return true;
            }
        }

        return false;
    }
}