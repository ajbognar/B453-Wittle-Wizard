using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction {
    up = 0, 
    left = 1, 
    down = 2, 
    right = 3
};

public class DungeonCrawlerController : MonoBehaviour
{
    public static List<Vector2Int> positionsVisited = new List<Vector2Int>();
    private static readonly Dictionary<Direction, Vector2Int> directionMovementMap = new Dictionary<Direction, Vector2Int> {
        {Direction.up, Vector2Int.up}, 
        {Direction.left, Vector2Int.left}, 
        {Direction.down, Vector2Int.down}, 
        {Direction.right, Vector2Int.right}
    };

    public static List<Vector2Int> GenerateDungeon(DungeonGenerationData dungeonData) {
        List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();
        for (int i = 0; i < dungeonData.numberOfCrawlers; ++i) {
            dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero));
        }

        int iterations = Random.Range(dungeonData.iterationsMin, dungeonData.iterationsMax);

        for (int i = 0; i < iterations; ++i) {
            foreach (DungeonCrawler dungeonCrawler in dungeonCrawlers) {
                Vector2Int newPos = dungeonCrawler.Move(directionMovementMap);
                if (!positionsVisited.Contains(newPos) && !newPos.Equals(Vector2Int.zero)){
                    positionsVisited.Add(newPos);
                }
                else {
                    iterations++;
                }
            }
        }

        return positionsVisited;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
