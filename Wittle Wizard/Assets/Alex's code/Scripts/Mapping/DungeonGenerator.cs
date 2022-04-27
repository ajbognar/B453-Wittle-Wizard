using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{

    public DungeonGenerationData DungeonGenerationData;

    private List<Vector2Int> dungeonRooms;
    // Start is called before the first frame update
    void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(DungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRooms(List<Vector2Int> rooms) {
        // load starting room
        RoomController.instance.LoadRoom("Room0", 0, 0);
        int count = 1;
        foreach(Vector2Int roomLocation in rooms) {
            if (count == rooms.Count) {
                RoomController.instance.LoadRoom("RoomEnd", roomLocation.x, roomLocation.y);
            }
            else {
                string newRoom = "Room" + count;
                count++;
                RoomController.instance.LoadRoom(newRoom, roomLocation.x, roomLocation.y);
            }
            
        }
    }
}
