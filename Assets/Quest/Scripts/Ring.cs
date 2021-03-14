using UnityEngine;
using UnityEngine.Events;

public class Ring : MonoBehaviour
{
    public UnityEvent OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        OnEnter.Invoke();
    }
}
