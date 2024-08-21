using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AnimationChanger : MonoBehaviour
{
    private const string Pulse = "Pulse";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator> ();
    }

    public void Pulsing()
    {
        _animator.SetBool (Pulse, true);
    }

    public void StopPulsing()
    {
        _animator.SetBool(Pulse, false);
    }
}