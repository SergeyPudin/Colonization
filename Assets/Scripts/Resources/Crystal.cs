using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private float _offsetY;

    private bool _isAssigned;
    private bool _isTransporting;

    private Transform _bot;

    public bool IsAssigned => _isAssigned;
    public bool IsTransporting => _isTransporting;

    private void Awake()
    {
        _isAssigned = false;
        _isTransporting = false;
    }
    private void Update()
    {
        Vector3 trunkPosition = new();

        if (_isTransporting == false || _bot == null)
        {
            return;
        }
        else
        {
            trunkPosition = _bot.position;
            trunkPosition.y = _offsetY;

            transform.position = trunkPosition;
        }
    }

    public void Assign()
    {
        _isAssigned = true;
    }

    public void Transport()
    {
        _isTransporting = true;
    }

    public void SetBot(Transform bot)
    {
        _bot = bot;
    }
}