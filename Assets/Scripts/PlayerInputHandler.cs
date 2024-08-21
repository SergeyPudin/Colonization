using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private BotButton _botButton;
    [SerializeField] private BaseButton _baseButton;
    [SerializeField] private LayerMask _raycastLayer;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private FlagPlacer _flagPlacer;

    private AnimationChanger _currentAnimationChanger;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUIElement())
                return;

            HandleRaycast();
        }
    }

    public bool IsPointerOverUIElement()
    {
        PointerEventData eventData = new PointerEventData(_eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        _graphicRaycaster.Raycast(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == _botButton.gameObject || result.gameObject == _baseButton.gameObject)
            {
                return true;
            }
        }

        return false;
    }

    private void HandleRaycast()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _raycastLayer))
        {
            GetCurrentBase(hit);
            TryChangeCurrentAnimation(hit);
            TryActivateButton(hit);
        }
        else
        {
            StopCurrentAnimation();
            _botButton.TurnOffButton();
            _baseButton.TurnOffButton();
        }
    }


    private void StopCurrentAnimation()
    {
        if (_currentAnimationChanger != null)
            _currentAnimationChanger.StopPulsing();

        _currentAnimationChanger = null;
    }

    private void TryChangeCurrentAnimation(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<AnimationChanger>(out AnimationChanger animationChanger))
        {
            _currentAnimationChanger = animationChanger;
            _currentAnimationChanger.Pulsing();
        }
    }

    private void TryActivateButton(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<BotSpawner>(out BotSpawner botSpawner))
        {
            _botButton.TurnOnButton(botSpawner);
        }
        
        if (hit.collider.TryGetComponent<Scanner>(out Scanner scanner))
        {
            _baseButton.TurnOnButton();
        }
    }

    private void GetCurrentBase(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<Base>(out Base commandCentr))
            _flagPlacer.GetBase(commandCentr);
    }
}