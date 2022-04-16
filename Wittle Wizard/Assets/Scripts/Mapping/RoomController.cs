using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInfo {
    public string name;
    public int x;
    public int y;

}

public class RoomController : MonoBehaviour
{
    public static RoomController instance;
    string currentWorldName = "Dungeon";
    RoomInfo currentLoadRoomData;
    Room currentRoom;
    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();
    public List<Room> loadedRooms = new List<Room>();
    bool isLoadingRoom = false;

    void Awake() {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex.Equals(0)) {
            // For testing with static generation
            LoadRoom("Room1", 0, 0);
            LoadRoom("Room0", -1, 0);
            LoadRoom("Room2", 1, 0);
            LoadRoom("Room4", 0, 1);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        UpdateRoomQueue();
    }

    public bool DoesRoomExist(int x, int y) {
        return loadedRooms.Find(item => item.x == x && item.y == y) != null;
    }

    public void LoadRoom(string name, int x, int y) {
        // if there is already a room in place, break
        if (DoesRoomExist(x, y)) {
            return;
        }
        // document new room's info
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.name = name;
        newRoomData.x = x;
        newRoomData.y = y;
        // add room to the queue
        loadRoomQueue.Enqueue(newRoomData);
    }

    IEnumerator LoadRoomRoutine(RoomInfo info) {
        string roomName = info.name;

        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while (loadRoom.isDone == false) {
            yield return null;
        }
    }

    public void RegisterRoom(Room room) {
        room.transform.position = new Vector3 (currentLoadRoomData.x * room.width, 
                                               currentLoadRoomData.y * room.height, 
                                               0);
        room.x = currentLoadRoomData.x;
        room.y = currentLoadRoomData.y;
        room.name = currentWorldName + "-" + currentLoadRoomData.name + " " + room.x + ", " + room.y;
        room.transform.parent = transform;

        isLoadingRoom = false;

        if (loadedRooms.Count == 0) {
            CameraController.instance.currentRoom = room;
        }

        loadedRooms.Add(room);
    }

    void UpdateRoomQueue() {
        if (isLoadingRoom) {
            return;
        }
        else if (loadRoomQueue.Count == 0) {
            return;
        }
        else  {
            currentLoadRoomData = loadRoomQueue.Dequeue();
            isLoadingRoom = true;
            StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
        }
    }

    public void OnPlayerEnterRoom(Room room) {
        CameraController.instance.currentRoom = room;
        
    }
}
