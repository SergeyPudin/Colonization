using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BotHandler))]
public class Scanner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenScans;
    [SerializeField] private float _scanRadius;

    private BotHandler _botHandler;

    private void Start()
    {
        _botHandler = GetComponent<BotHandler>();
        
        StartCoroutine(OnScanning());
    }

    private IEnumerator OnScanning()
    {
        WaitForSeconds waitForSeconds = new(_timeBetweenScans);

        while (enabled)
        {
            ScanClosestCrystal(out Crystal crystal);

            if (crystal != null && crystal.IsAssigned == false)
                _botHandler.AssignCrystal(crystal);

            yield return waitForSeconds;
        }
    }

    private void ScanClosestCrystal(out Crystal currentCrystal)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _scanRadius);
        float minDistance = float.MaxValue;
        currentCrystal = null;

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent<Crystal>(out Crystal crystal) && crystal.IsAssigned == false)
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    currentCrystal = crystal;
                }
            }
        }
    }
}