using UnityEngine;
using UnityEngine.Events;

public class CrystalAcceptor : MonoBehaviour
{
    public event UnityAction CrystalUploaded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crystal>(out _))
        {
            CrystalUploaded?.Invoke();

            Destroy(other.gameObject);
        }
    }
}