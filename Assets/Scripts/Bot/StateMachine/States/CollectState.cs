using UnityEngine;

public class CollectState : State
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crystal>(out Crystal crystal))
        {
            if (crystal.IsAssigned && crystal.IsTransporting == false)
            {
                TakeCrystal(crystal);

                NeedTransit();
            }
        }
    }

    private void TakeCrystal(Crystal crystal)
    {
        crystal.SetBot(this.transform);
        crystal.Transport();
    }
}