using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    Vector3 mouseLocation = new Vector3(0, 0, 0);

    bool attackDown = false;

    float attackCharge = 0;

    bool animInitiated = false;

    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = GameObject.FindWithTag("PlayerShotRenderer").GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos;

        newPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseLocation.x, mouseLocation.y, 0));

        newPos.z = 0;

        transform.up = newPos - transform.position;

        if(attackDown)
        {

            attackCharge += Time.deltaTime;

            if (!animInitiated)
            {
                GetComponent<Animator>().Play("BowPull");
                animInitiated = true;

            }



        } else
        {

            animInitiated = false;

            GetComponent<Animator>().Play("bow_idle");

            if (attackCharge >= 1.5)
            {
                Shoot();
            }

            attackCharge = 0;

        }

    }

    void OnMouseLoc(InputValue input)
    {

        Vector2 inputVec = input.Get<Vector2>();

        mouseLocation = new Vector2(inputVec.x, inputVec.y);

    }

    public void OnAttackDown( )
    {

        attackDown = true;

    }

    public void OnAttackUp()
    {
        attackDown = false;
    }

    void Shoot()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up);
        if (hitInfo)
        {

            line.SetPosition(0, transform.position);
            line.SetPosition(1, new Vector3(hitInfo.point.x, hitInfo.point.y, 0));

            StartCoroutine(ShotDecay());
               
            Instantiate(Resources.Load<GameObject>("Prefabs/ArrowHitEffect"), hitInfo.point, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - 180), null);
            Instantiate(Resources.Load<GameObject>("Prefabs/RemnantArrow"), hitInfo.point, transform.rotation, GameObject.FindWithTag("Level").transform);

        }

    }

    IEnumerator ShotDecay()
    {



        line.enabled = true;

        line.startWidth = 0.25f;
        line.endWidth = 0.25f;
        yield return new WaitForSeconds(0.05f);
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        yield return new WaitForSeconds(0.05f);
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;
        yield return new WaitForSeconds(0.05f);
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        yield return new WaitForSeconds(0.05f);
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;

        yield return new WaitForSeconds(0.05f);
        line.enabled = false;

    }

}
