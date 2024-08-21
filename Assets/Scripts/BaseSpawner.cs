using System.Linq;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    [SerializeField] private Base _basePrefab;
    [SerializeField] private SpawnPlate _spawnPlate;
    [SerializeField] private ResourceCounter _counter;

    public void CreateBase(Transform spawnPlace = null, int numberBots = 1)
    {
        Vector3 position = spawnPlace != null ? spawnPlace.position : _spawnPlate.SpawnRandomPosition();

        Base newBase = Instantiate(_basePrefab, position, Quaternion.identity);

        if (newBase.TryGetComponent<BotSpawner>(out BotSpawner botSpawner))
        {
            for (int i = 0; i < numberBots; i++)
            {
                botSpawner.CreateBot();
            }
        }

        if (newBase.TryGetComponent<BotHandler>(out BotHandler botHandler))
        {
            botHandler.GetCounter(_counter);
        }

        AddCrystalAcceptor(newBase);

        _counter.IsAffordBase();
    }

    private void AddCrystalAcceptor(Base newBase)
    {
        CrystalAcceptor acceptor = newBase.GetComponentsInChildren<CrystalAcceptor>().FirstOrDefault();

        if (acceptor != null)
            _counter.AddCrystalAcceptor(acceptor);
    }
}