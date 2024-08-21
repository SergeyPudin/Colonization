using UnityEngine;

public class Flag : MonoBehaviour 
{
    private bool _isAssigned;
    private BaseSpawner _baseSpawner;

    public bool IsAssigned => _isAssigned;

    private void Awake()
    {
        _isAssigned = false;
    }

    public void Assign()
    {
        _isAssigned = true;
    }

    public void Unassign()
    {
        _isAssigned = false;
    }

    public void GetBaseSpawner(BaseSpawner baseSpawner)
    {
        _baseSpawner = baseSpawner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isAssigned && other.TryGetComponent<Bot>(out Bot bot))
        {
            Destroy(bot.gameObject);
            _baseSpawner.CreateBase(this.transform);
            Destroy(gameObject);
        }
    }
}