using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float moveSpeed;

    GameController myGameCtrl;

    private float temp = 0f;
    private float increaseScore;

    private void Start()
    {
        myGameCtrl = FindObjectOfType<GameController>();
        moveSpeed = 7f;
        temp = 0f;
        increaseScore = 15f;
    }
    
    private void Update()
    {
        if (myGameCtrl.GetGameover())
        {
            return;
        }
        if (myGameCtrl.GetScore() > increaseScore && temp < 1)
        {
            moveSpeed += .5f;
            increaseScore += 15f;
            temp++;
        }
        else
        {
            temp = 0f;
        }
        moveOnLeft();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }

    private void moveOnLeft()
    {
        Vector2 moveLeft = transform.position;
        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            moveLeft += Vector2.left * (moveSpeed * speedUp) * Time.deltaTime;
        }
        else
        {
            moveLeft += Vector2.left * moveSpeed * Time.deltaTime;
        }*/
        moveLeft += Vector2.left * moveSpeed * Time.deltaTime;
        transform.position = moveLeft;
        Debug.Log(moveSpeed);
    }
}
