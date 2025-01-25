using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JustOnceTrigger : MonoBehaviour
{
    public UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onTrigger.Invoke();
            gameObject.SetActive(false);
        }
    }
}
