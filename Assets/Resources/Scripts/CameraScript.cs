using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public string startingRoomId = "TestRoom01";
    public string startingEntranceId = "01";

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        GameObject newRoom = Instantiate(Resources.Load<GameObject>("Rooms/" + startingRoomId), new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), null);
        Vector3 spawnPos = newRoom.transform.Find("Entrance_" + startingEntranceId).gameObject.transform.Find("SpawnPos").position;
        GameObject player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), new Vector3(spawnPos.x, spawnPos.y - 0.5f, spawnPos.z), new Quaternion(0,0,0,0), null);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
