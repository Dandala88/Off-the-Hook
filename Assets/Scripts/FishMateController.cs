using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishMateController : MonoBehaviour
{
    public UnityEvent gameFailedEvent;
    public UnityEvent gameWonEvent;
    private void OnTriggerEnter(Collider other)
    {
        var fish = other.GetComponent<FishController>();
        if(fish != null)
        {
            if(GameManager.Instance.calories < GameManager.Instance.calorieTarget)
            {
                gameFailedEvent.Invoke();
            }
            else
            {
                gameWonEvent.Invoke();
            }
        }
    }
}
