using System;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    public Flag Flag { get; private set; }
    
    public Transform[] WayPoints => _wayPoints;

    public void SetFlag(Flag flag)
    {
        Flag = flag;
    }

    public void DestroyFlag()
    {
        Destroy(Flag.gameObject);
        this.Flag = null;
    }

    internal bool TryGettComponentInChildren<T>(out T crystalAcceptor)
    {
        throw new NotImplementedException();
    }
}