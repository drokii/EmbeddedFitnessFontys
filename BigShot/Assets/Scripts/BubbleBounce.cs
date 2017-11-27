using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBounce : MonoBehaviour {
    int edgeX, edgeY;
    bool movingRight, movingDown, movingUp, movingLeft;

	// Use this for initialization
	void Start () {
        edgeX = Screen.width;
        edgeY = Screen.height;
        switch(Random.Range(1, 3))
        {
            case 1:
                movingRight = true;
                break;
            case 2:
                movingLeft = true;
                break;
            case 3:
                movingRight = false;
                movingLeft = false;
                break;
        }
        switch (Random.Range(1, 3))
        {
            case 1:
                movingUp = true;
                break;
            case 2:
                movingDown = true;
                break;
            case 3:
                movingUp = false;
                movingDown = false;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < edgeX && movingRight)
        {
            transform.Translate(1, 0, 0);
        }
        else if (transform.position.x > 0)
        {
            transform.Translate(-1, 0, 0);
            movingRight = false;
            movingLeft = true;
        }

        if (transform.position.x > 0 && movingLeft)
        {
            transform.Translate(-1, 0, 0);
        }
        else if (transform.position.x < edgeX)
        {
            transform.Translate(1, 0, 0);
            movingRight = true;
            movingLeft = false;
        }

        if (transform.position.y < edgeY && movingDown)
        {
            transform.Translate(0, 1, 0);
        }
        else if (transform.position.y > 0)
        {
            transform.Translate(0, -1, 0);
            movingDown = false;
            movingUp = true;
        }

        if (transform.position.y > 0 && movingUp)
        {
            transform.Translate(0, -1, 0);
        }
        else if (transform.position.y < edgeY)
        {
            transform.Translate(0, 1, 0);
            movingDown = true;
            movingUp = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        Debug.Log(transform.position.x);
        if (collision.transform.position.x > transform.position.x)
        {
            movingLeft = true; movingRight = false;
        }
        else
        {
            movingLeft = false; movingRight = true;
        }
        if (collision.transform.position.y > transform.position.y)
        {
            movingUp = true; movingDown = false;
        }
        else
        {
            movingUp = false; movingDown = true;
        }
    }
}
