using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public int width;
    public int height;
    public int x;
    public int y;
    // Start is called before the first frame update
    void Start()
    {
        if(RoomController.instance == null)
        {
            Debug.Log("Wrong Scene");
            return;
        }

        RoomController.instance.RegisterRoom(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetRoomCenter() {
        return new Vector3(x * width, y * height);
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }

}
