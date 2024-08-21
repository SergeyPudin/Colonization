using System.Collections;
using UnityEngine;

public class CrystallSpawner : MonoBehaviour
{
    [SerializeField] private Crystal _crystal;
    [SerializeField] private SpawnPlate _spawnPlate;
    [SerializeField] private float _secondsBetweenSpawns;

    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(OnSpawn());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator OnSpawn()
    {
        WaitForSeconds waitForSeconds = new(_secondsBetweenSpawns);

        while (enabled)
        {
            yield return waitForSeconds;

            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(_crystal.gameObject, _spawnPlate.SpawnRandomPosition(),Quaternion.identity);
    }
}