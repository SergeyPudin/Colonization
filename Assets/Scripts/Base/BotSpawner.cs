using UnityEngine;

[RequireComponent(typeof(Base), typeof(BotHandler))]
public class BotSpawner : MonoBehaviour
{
    [SerializeField] private Bot _botPrefab;
    [SerializeField] private float _offsetHalvingXZ = 1f;

    private Base _base;
    private BotHandler _botHandler;

    private void Awake()
    {
        _base = GetComponent<Base>();
        _botHandler = GetComponent<BotHandler>();
    }

    public void CreateBot()
    {
        Bot newBot = Instantiate(_botPrefab, SpawnPlace(), Quaternion.identity);
        
        TryGetWaypoints(newBot);
        _botHandler.SetBot(newBot);
    }

    private void TryGetWaypoints(Bot newBot)
    {
        if (newBot.TryGetComponent<PatrolState>(out PatrolState patrolState))
            patrolState.GetWaypoints(_base.WayPoints);
    }

    private Vector3 SpawnPlace()
    {
        float xValue = Random.Range(-_offsetHalvingXZ, _offsetHalvingXZ);
        float zValue = Random.Range(-_offsetHalvingXZ, _offsetHalvingXZ);

        int randomWaypointIndex = Random.Range(0, _base.WayPoints.Length - 1);

        Vector3 offset = new Vector3(xValue, 0, zValue);

        return _base.WayPoints[randomWaypointIndex].transform.position + offset;
    }
}
