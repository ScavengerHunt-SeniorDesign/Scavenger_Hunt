using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneration : MonoBehaviour
{
    [SerializeField]
    private int numberOfItems;

    [SerializeField]
    private GameObject[] itemPrefab;

    public void GenerateItems(int mapDepth, int mapWidth, float distanceBetweenVertices, LevelData levelData)
    {
        var prevCoords = new List<(int, int)> {};

        for (int i = 0; i < numberOfItems; i++) 
        {
            int a, b;

            // generate random numbers that have not been previously used
            // TODO - Make sure items do not spawn in positions where trees are located
            do {
                a = Random.Range(1, mapDepth);
                b = Random.Range(1, mapWidth);
            } while (prevCoords.Contains((a, b)));

            // Convert from level coordinate system to tile coordinate system and retrieve the corresponding tile data
            TileCoordinate tileCoordinate = levelData.ConvertToTileCoordinate(a, b);
            TileData tileData = levelData.tilesData[tileCoordinate.tileZIndex, tileCoordinate.tileXIndex];
            int tileWidth = tileData.heightMap.GetLength(1);

            // Calculate the mesh vertex index
            Vector3[] meshVertices = tileData.mesh.vertices;
            int vertexIndex = tileCoordinate.coordinateZIndex * tileWidth + tileCoordinate.coordinateXIndex;

            // add index to previous coordinates used
            prevCoords.Add((a, b));

            // place randomly selected item at index
            Vector3 itemPosition = new Vector3(b * distanceBetweenVertices, meshVertices[vertexIndex].y, a * distanceBetweenVertices);
            GameObject item = Instantiate(this.itemPrefab[Random.Range(0, itemPrefab.Length)], itemPosition, Quaternion.identity) as GameObject;




        }

        



    }
}
