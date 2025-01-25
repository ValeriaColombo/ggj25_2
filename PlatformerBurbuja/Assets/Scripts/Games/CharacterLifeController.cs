using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLifeController : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Game game;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SiTocaSeMuere")
        {
            Debug.Log("Auch!");
            transform.position = respawnPoint.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "2ndChance")
        {
            game.Get2ndChance();
        }
    }
}
