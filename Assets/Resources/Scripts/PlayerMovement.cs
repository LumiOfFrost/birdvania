using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 movement = new Vector2(0, 0);
    Vector2 aim = new Vector2(0, 0);
    Vector2 mouseLocation = new Vector2(0, 0);
    Rigidbody2D rb;
    public float speed = 4;
    float coyoteTime = 0.15f;
    float jumpBuffer = 0.1f;
    [HideInInspector]
    public bool grounded = true;
    public float jumpHeight = 4;

    // Start is called before the first frame update
    void Start()
    {
        coyoteTime = 0;
        jumpBuffer = -1;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        jumpBuffer -= Time.deltaTime;
        coyoteTime -= Time.deltaTime;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 veloc = rb.velocity;
        if (movement.x > 0 && veloc.x <= speed)
        {
            veloc.x = speed;
        }
        else if (movement.x < 0 && veloc.x >= -1 * speed)
        {
            veloc.x = speed * -1;
        }

        if (coyoteTime >= 0 && jumpBuffer >= 0)
        {

            coyoteTime = -1;
            jumpBuffer = -1;
            veloc.y = jumpHeight;
            GetComponent<PlayerAnimation>().Jump();

        }

        rb.velocity = veloc;

        if (grounded)
        {
            coyoteTime = 0.15f;
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

    void OnResetItems(InputValue input)
    {

        PlayerPrefs.SetInt("HasBow", 0);

    }

    void OnMouseLoc(InputValue input)
    {

        Vector2 inputVec = input.Get<Vector2>();

        mouseLocation = new Vector2(inputVec.x, inputVec.y);

    }

    void OnJump()
    {

        jumpBuffer = 0.1f;

    }

}
