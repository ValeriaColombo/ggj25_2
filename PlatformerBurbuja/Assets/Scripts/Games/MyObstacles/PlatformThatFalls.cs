using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformThatFalls : MonoBehaviour
{
    [SerializeField] private Transform platform;
    [SerializeField] private Collider triggerCollider;
    [SerializeField] private float shakingTime;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float respawnTime;

    private bool isFalling = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isFalling && other.tag == "Player")
        {
            triggerCollider.enabled = false;
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        isFalling = true;

        //Shake
        float shakingFor = 0;
        while (shakingFor < shakingTime)
        {
            shakingFor += Time.fixedDeltaTime;
            platform.rotation = Quaternion.Euler(0, 0, Random.Range(-1f, 1f));
            yield return new WaitForEndOfFrame();
        }

        //Fall
        float fallingFor = 0;
        while (fallingFor < respawnTime)
        {
            fallingFor += Time.fixedDeltaTime;
            platform.transform.Translate(0, -fallSpeed * Time.fixedDeltaTime, 0);
            yield return new WaitForEndOfFrame();
        }

        //Respawn
        platform.localPosition = Vector3.zero;

        triggerCollider.enabled = true;
        isFalling = false;
    }
}
