using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawler : MonoBehaviour
{
    public Vector2Int Position {get; set;}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DungeonCrawler(Vector2Int startPos) {
        Position = startPos;
    }

    public Vector2Int Move(Dictionary<Direction, Vector2Int> directionMovementMap) {
        // chooses a random direction to move
        Direction toMove = (Direction)Random.Range(0, directionMovementMap.Count);
        // pulls from the dictionary to move in a direction
        Position += directionMovementMap[toMove];
        return Position;
    }
}
