using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGeneration : MonoBehaviour
{
    [SerializeField]
    private int numberOfPortals;

    [SerializeField]
    private GameObject portalPrefab;

    [SerializeField]
    private GameObject puzzleRoomPrefab;

    public void GeneratePortals(int mapDepth, int mapWidth, float distanceBetweenVertices, LevelData levelData)
    {
        var prevCoords = new List<(int, int)> {};
        int puzzleRoomOffset = 0; // distance to place puzzle rooms away from each other

        for (int i = 0; i < numberOfPortals; i++) 
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

            // place portal selected item at index
            Vector3 portalPosition = new Vector3(b * distanceBetweenVertices, meshVertices[vertexIndex].y + 2, a * distanceBetweenVertices);
            GameObject portal = Instantiate(this.portalPrefab, portalPosition, Quaternion.identity) as GameObject;
            portal.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);       // Allows us to change the size of the portal assets

            // place corresponding puzzle room located away from map
            Vector3 puzzleRoomPosition = new Vector3(75 + puzzleRoomOffset, -20, 115);
            GameObject puzzleRoom = Instantiate(this.puzzleRoomPrefab, puzzleRoomPosition, Quaternion.identity) as GameObject;

            puzzleRoomOffset += 10;

        }
    }
}
