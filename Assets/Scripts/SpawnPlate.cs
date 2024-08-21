using UnityEngine;

public class SpawnPlate : MonoBehaviour
{
    public Vector3 SpawnRandomPosition()
    {
        if (TryGetComponent<Collider>(out Collider collider))
        {
            Bounds bounds = collider.bounds;

            float positionX = Random.Range(bounds.min.x, bounds.max.x);
            float positionZ = Random.Range(bounds.min.z, bounds.max.z);
            float positionY = 0;

            return new Vector3(positionX, positionY, positionZ);
        }
        else
        {
            return Vector3.zero;
        }
    }
}