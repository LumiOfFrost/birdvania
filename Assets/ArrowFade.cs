using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFade : MonoBehaviour
{

    SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        StartCoroutine(ArrowDafe());
    }

    IEnumerator ArrowDafe()
    {

        Color col = spr.color;

        yield return new WaitForSeconds(4.5f);
        col = new Color(col.r, col.g, col.b, 0.75f);
        yield return new WaitForSeconds(0.125f);
        col = new Color(col.r, col.g, col.b, 0.5f);
        yield return new WaitForSeconds(0.125f);
        col = new Color(col.r, col.g, col.b, 0.25f);
        yield return new WaitForSeconds(0.125f);
        GameObject.Destroy(this.gameObject);

    }

}
