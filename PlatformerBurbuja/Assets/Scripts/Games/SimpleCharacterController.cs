using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleCharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private Game game;

    [SerializeField] private float ScalePerMovement = 0.1f;
    [SerializeField] private float ScalePerSoap = 0.1f;
    private float currentScale;

    private Vector2 currentSpeed = Vector2.zero;

    private void Start()
    {
        currentScale = transform.localScale.x;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            currentSpeed.x = speed * Time.fixedDeltaTime;
            Downsize();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Downsize();
            currentSpeed.x = -speed * Time.fixedDeltaTime;
        }
        else if(Mathf.Abs(currentSpeed.x) < (speed * Time.fixedDeltaTime)/2f)
        {
            currentSpeed.x = 0;
        }
        else if(currentSpeed.x > 0)
        {
            currentSpeed.x -= speed/2 * Time.fixedDeltaTime;
        }
        else if(currentSpeed.x < 0)
        {
            currentSpeed.x += speed/2 * Time.fixedDeltaTime;
        }

        if (isTouchingWall && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            currentSpeed.y = speed * Time.fixedDeltaTime * 3;
        }
        else if (isTouchingWall)
        {
            currentSpeed.y = 0;
        }

        if (!isTouchingWall && isTouchingFloor && currentSpeed.y == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Downsize();
            currentSpeed.y += speed * Time.fixedDeltaTime * 5;
        }
        else if(!isTouchingWall && currentSpeed.y > 0)
        {
            currentSpeed.y -= speed * Time.fixedDeltaTime / 5;
        }
        else if(!isTouchingWall)
        {
            currentSpeed.y = 0;
        }

        rb.velocity = currentSpeed;
    }

    private void Downsize()
    {
        currentScale -= ScalePerMovement;
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);

        if(currentScale <= ScalePerMovement)
        {
            game.GameOver();
        }
    }

    public bool isTouchingWall = false;
    public bool isTouchingFloor = false;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
            isTouchingWall = false;
        else if (collision.gameObject.tag == "floor")
            isTouchingFloor = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
            isTouchingWall = true;
        else if (collision.gameObject.tag == "floor")
            isTouchingFloor = true;
        else if (collision.gameObject.tag == "SiTocaSeMuere")
        {
            Debug.Log("Auch!");
            game.GameOver();
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "2ndChance")
        {
            game.Get2ndChance();
        }
        else if (collision.tag == "jabon")
        {
            currentScale += ScalePerSoap;
            transform.localScale = new Vector3(currentScale, currentScale, currentScale);
            collision.gameObject.SetActive(false);
        }
    }


}
