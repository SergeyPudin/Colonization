using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BotHandler), typeof(Base))]
public class Scanner : MonoBehaviour
{
    [SerializeField] private float _scanInterval;
    [SerializeField] private float _scanRadius;

    private BotHandler _botHandler;
    private Base _base;

    private void Start()
    {
        _botHandler = GetComponent<BotHandler>();
        _base = GetComponent<Base>();

        StartCoroutine(OnScanning());
    }

    private IEnumerator OnScanning()
    {
        WaitForSeconds waitForSeconds = new(_scanInterval);

        while (enabled)
        {
            Scan();

            yield return waitForSeconds;
        }
    }

    private void Scan()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _scanRadius);

        FindFlag();
        FindCrystal(hits);
    }

    private void FindCrystal(Collider[] hits)
    {
        Crystal currentCrystal = null;
        float minDistance = float.MaxValue;

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

        if (currentCrystal != null && currentCrystal.IsAssigned == false)
            _botHandler.AssignCrystal(currentCrystal);
    }

    private void FindFlag()
    {
        if (_base.Flag != null && _base.Flag.IsAssigned == false)
        {
            _botHandler.AssignFlag();
        }
    }
}