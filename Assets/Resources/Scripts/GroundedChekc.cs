using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChekc : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Ground"))
        {

            transform.parent.gameObject.GetComponent<PlayerMovement>().grounded = true;

        }  

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Ground"))
        {

            transform.parent.gameObject.GetComponent<PlayerMovement>().grounded = false;

        }

    }

}
