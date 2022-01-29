using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHitEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheBoy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TheBoy()
    {

        yield return new WaitForSeconds(0.75f);
        GameObject.Destroy(this.gameObject);

    }

}
