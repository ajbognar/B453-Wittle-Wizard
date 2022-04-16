using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New MapData")]
public class MapData : ScriptableObject
{

    
    public GameObject[] rooms;
    public int[,] grid;
    void Start() {
        // makeMap();
    }

    void makeMap() {
        Debug.Log("I EXIST");
        rooms = new GameObject[5];
        for (int i = 0; i < 5; ++i) {
            string fileName = i + "RoomStruct";
            rooms[i] = Resources.Load("rooms/" + fileName) as GameObject;
        }
        grid = new int[5, 5];
        for (int i = 1; i < 6; ++i) {
            grid[2, (i-1)] = i;
        }
        int count = 1;
        while (count < 6) {
            for (int i = 0; i < 5; ++i) {
                for (int j = 0; j < 5; ++j) {
                    if (grid[i, j] == count) {
                        Instantiate(rooms[count - 1], 
                        new Vector3(i * 20, j * 16, 0),
                        Quaternion.identity);
                    }
                }
            }
        }
        
    }
}
