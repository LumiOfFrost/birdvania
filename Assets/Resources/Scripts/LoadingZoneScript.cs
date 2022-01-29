using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingZoneScript : MonoBehaviour
{

    public string entranceID = "01";
    public string roomID = "TestRoom01";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {

            StartCoroutine(FadeAndSwitchRooms(collision.gameObject));

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeAndSwitchRooms(GameObject collision)
    {

        GameObject cam = GameObject.FindWithTag("MainCamera");

        collision.GetComponent<PlayerMovement>().enabled = false;
        cam.transform.Find("RoomFade").gameObject.GetComponent<Animator>().Play("RoomFadeOut");
        yield return new WaitForSeconds(0.5f);
        GameObject newRoom = Instantiate(Resources.Load<GameObject>("Rooms/" + roomID), new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), null);
        Vector3 spawnPos = newRoom.transform.Find("Entrance_" + entranceID).gameObject.transform.Find("SpawnPos").position;
        collision.transform.position = new Vector3(spawnPos.x, spawnPos.y - 0.5f, spawnPos.z);
        GameObject.Destroy(this.transform.parent.gameObject);
        collision.GetComponent<PlayerMovement>().enabled = true;

    }

}
