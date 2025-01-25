using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterLifeController : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Game game;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SiTocaSeMuere")
        {
            Debug.Log("Auch!");
            SceneManager.LoadScene("Lost");
//            transform.position = respawnPoint.position;
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
