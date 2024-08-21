using UnityEngine;
using UnityEngine.UI;

public class FlagPlacer : MonoBehaviour
{
    [SerializeField] private Flag _flagPrefab;
    [SerializeField] private LayerMask _raycastLayer;
    [SerializeField] private Button _baseButton;
    [SerializeField] private BaseSpawner _baseSpawner;

    private Base _commandCentr;
    private Flag _temporraryFlag;
    private bool _isFlagPlacementActive;

    private void Awake()
    {
        _temporraryFlag = Instantiate(_flagPrefab);
        _temporraryFlag.gameObject.TryGetComponent<Flag>(out Flag flag);
        flag.enabled = false;
        _isFlagPlacementActive = false;
    }

    private void OnEnable()
    {
        _temporraryFlag.gameObject.SetActive(false);
        _baseButton.onClick.AddListener(StartFlagPlacement);
    }

    private void OnDisable()
    {
        _baseButton.onClick.RemoveListener(StartFlagPlacement);
    }

    private void Update()
    {
        if (_isFlagPlacementActive)
        {
            UpdateTemporaryFlagPosition();
            HandleFlagPlacement();
        }
    }

    public void GetBase(Base commandCentr)
    {
        _commandCentr = commandCentr;
    }

    private void UpdateTemporaryFlagPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        _temporraryFlag.gameObject.SetActive(true);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _raycastLayer))
        {
            _temporraryFlag.transform.position = hit.point;
        }
    }

    private void HandleFlagPlacement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_commandCentr.Flag == null)
            {
                PlaceFlag();
            }
            else
            {
                _commandCentr.DestroyFlag();
                PlaceFlag();
            }
        }
    }

    private void PlaceFlag()
    {
            Flag newFlag = Instantiate(_flagPrefab, _temporraryFlag.transform.position, Quaternion.identity);
            newFlag.GetBaseSpawner(_baseSpawner);

            _temporraryFlag.gameObject.SetActive(false);
            _isFlagPlacementActive = false;

            _commandCentr.SetFlag(newFlag);
    }

    private void StartFlagPlacement()
    {
        _isFlagPlacementActive = true;
    }
}