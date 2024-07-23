using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public bool atTop = false;
    //public bool atBottom = false;
    public bool inside = false;
    public GameManagerBall gameManager;
    public MovementScript movementScript;

    //public int score = 0;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Exit"))
        {
            if (atTop == true && inside == true)
            {
                atTop = false;
                inside = false;
                //Debug.Log("scored "+ score);
                //score += 1;

                gameManager.PlayerScored();
                GetComponent<MovementScript>().direction *= -1;
            }
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)

        {
            if (collision.CompareTag("Inside"))
            {
                inside = true;
            }

        if (collision.CompareTag("Enter"))
        {
            atTop = true;
        }
    }

    
}
