using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;   // Assign a Cube prefab
    public int rows = 5;             // Number of rows
    public int columns = 8;          // Number of columns
    public float spacing = 0.1f;     // Space between bricks
    public Vector2 startPosition = new Vector2(-3.5f, 4f); // Where to start spawning

    void Start()
    {
        SpawnBricks();
    }

    void SpawnBricks()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 spawnPos = new Vector2(
                    startPosition.x + col * (1f + spacing),
                    startPosition.y - row * (0.5f + spacing)
                );

                Instantiate(brickPrefab, spawnPos, Quaternion.identity, transform);
            }
        }
    }
}
