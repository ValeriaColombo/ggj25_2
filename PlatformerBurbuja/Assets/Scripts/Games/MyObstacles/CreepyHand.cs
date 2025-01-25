using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyHand : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator.enabled = false;
        StartCoroutine(StartAnimInRandomTime());
    }

    private IEnumerator StartAnimInRandomTime()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        animator.enabled = true;
    }
}
