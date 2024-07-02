using System.Collections;
using UnityEngine;

public class CrystallSpawner : MonoBehaviour
{
    [SerializeField] private Crystal _crystal;
    [SerializeField] private float _secondsBetweenSpawns;
    [SerializeField] private GameObject _spawnPlate;

    private Coroutine _spawnCoroutine;
    private Collider _spawnPlateCollider;

    private void Start()
    {
        _spawnPlateCollider = _spawnPlate.GetComponent<Collider>();
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
        Instantiate(_crystal.gameObject, SpawnPlace(),Quaternion.identity);
    }

    private Vector3 SpawnPlace()
    {
        Bounds bounds = _spawnPlateCollider.bounds;

        float positionX = Random.Range(bounds.min.x, bounds.max.x);
        float positionZ = Random.Range(bounds.min.z, bounds.max.z);
        float positionY = 0;

        return new Vector3(positionX, positionY, positionZ);
    }
}