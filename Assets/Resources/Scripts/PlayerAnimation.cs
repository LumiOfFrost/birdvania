using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{

    Vector2 movement = new Vector2(0, 0);

    Vector2 aim = new Vector2(0, 0);

    Vector2 mouseLocation = new Vector2(0, 0);

    float jumpTime = 0;

    Animator anim;

    [HideInInspector]
    public bool updateAnims = true;


    // Start is called before the first frame update
    void Start()
    {
        updateAnims = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        jumpTime -= Time.deltaTime;
        
        if(updateAnims)
        {
            if (movement.x != 0 && GetComponent<PlayerMovement>().grounded & jumpTime <= 0)
            {

                anim.Play("Run");

            }
            else if (GetComponent<PlayerMovement>().grounded && jumpTime <= 0)
            {
                anim.Play("Idle");

            }

            if (movement.x != 0)
            {
                if (movement.x < 0)
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, 1);
                }
            }
        }

    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        movement = new Vector2(inputVec.x, inputVec.y);
    }

    void OnAim(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        aim = new Vector2(inputVec.x, inputVec.y);
    }



    void OnMouseLoc(InputValue input)
    {

        Vector2 inputVec = input.Get<Vector2>();

        mouseLocation = new Vector2(inputVec.x, inputVec.y);

    }

    public void Jump()
    {

        jumpTime = 0.1f;

        if (GetComponent<Rigidbody2D>().velocity.x > 0.5f)
        {

            anim.Play("Jump");

        } else
        {
            anim.Play("JumpStationary");
        }

    }
    public IEnumerator GetItem(float SecondsToWait)
    {

        updateAnims = false;

        anim.Play("GetItem");
        yield return new WaitForSeconds(SecondsToWait);
        updateAnims = true;


    }

}
