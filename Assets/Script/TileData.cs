using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using Random = System.Random;
using System.Threading;
using TMPro;
using Unity.Mathematics;

public class TileData : MonoBehaviour
{

    public Tile redSquare;
    public Tile greenSquare;

    public Vector3Int position;
    public Vector3Int currentPosition;

    public Tilemap tilemap;
    public Tilemap tilemapEnded;

    public int score;
    public TextMeshProUGUI scoreText;

    public List<Vector3Int> usedPositions;

    void Start()
    {
        usedPositions = new List<Vector3Int>();
        Vector3Int zeroPos = new Vector3Int(0, 0, 0);
        usedPositions.Add(zeroPos);
    }

    void Update()
    {
        scoreText.text = score.ToString();
        PlayerPrefs.SetString("Score", scoreText.text);
    }

    void OnMouseDown()
    {
        // save the camera as public field if you using not the main camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // get the collision point of the ray with the z = 0 plane
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        Vector3Int currentPosition = tilemap.WorldToCell(worldPoint);

        Random rnd = new Random();
        int index = 0;
        do
        {
            // get a random position on the grid
            int randomX = rnd.Next(-4, 5);
            int randomY = rnd.Next(-4, 5);

            index = usedPositions.FindIndex(pos => pos.x == randomX && pos.y == randomY);
            position.Set(randomX, randomY, 0);

            if (index != -1)
            {
                Console.WriteLine("Position: " + randomX + " " + randomY + " already used");
            }

        } while (index != -1 && usedPositions.Count != 81);

        //choose the next tile and add score
        tilemap.SetTile(position, redSquare);
        score++;

        //change the tile to green
        tilemapEnded.SetTile(currentPosition, greenSquare);
        usedPositions.Add(position);
    }
}