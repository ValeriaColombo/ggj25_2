using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private InfiniteTrigger enterPortalTrigger;
    [SerializeField] private Transform exitSpawnPoint;
    [SerializeField] private Transform player;

    private void Awake()
    {
        enterPortalTrigger.onTrigger.AddListener(EnterPortal);
    }

    private void EnterPortal()
    {
        player.transform.position = exitSpawnPoint.position;
    }
}
