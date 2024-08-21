using UnityEngine;

public class StartConfig : MonoBehaviour
{
    [SerializeField] private int _startingBaseCount;
    [SerializeField] private int _startingBotCount;
    [SerializeField] private BaseSpawner _baseSpawner;

    private void Start()
    {
        Transform nullPosition = null;
        for (int i = 0; i < _startingBaseCount; i++)
        {
            _baseSpawner.CreateBase(nullPosition, _startingBotCount);
        }
    }
}
