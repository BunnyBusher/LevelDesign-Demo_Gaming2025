using UnityEngine;
using UnityEngine.Events;

public class VictoryCheck : MonoBehaviour
{
    public UnityEvent onVictory;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) Debug.Log("Win");
    }
}
