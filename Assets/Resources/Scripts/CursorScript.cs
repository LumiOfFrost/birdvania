using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorScript : MonoBehaviour
{

    Vector3 mouseLocation = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos;

        newPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseLocation.x, mouseLocation.y, 0));

        newPos.z = 0;

        transform.position = newPos;
    }

    void OnMouseLoc(InputValue input)
    {

        Vector2 inputVec = input.Get<Vector2>();

        mouseLocation = new Vector2(inputVec.x, inputVec.y);

    }

}
