using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {
	// Attributes of Level Generation
	[SerializeField]
	private int mapWidthInTiles, mapDepthInTiles;			// Controls the overall size of the level generated

	[SerializeField]
	private GameObject tilePrefab;							// Allows selection of prefab as a template to clone multiple tiles based on the size

	[SerializeField]
	private float centerVertexZ, maxDistanceZ;

	void Start()
	{
		GenerateMap ();
	}

	void GenerateMap()
	{
		// Obtain tile dimensions from the tile Prefab
		Vector3 tileSize = tilePrefab.GetComponent<MeshRenderer> ().bounds.size;
		int tileWidth = (int)tileSize.x;
		int tileDepth = (int)tileSize.z;

		// For each Tile, instantiate a Tile in the correct position
		for (int xTileIndex = 0; xTileIndex < mapWidthInTiles; xTileIndex++)
		{
			for (int zTileIndex = 0; zTileIndex < mapDepthInTiles; zTileIndex++)
			{
				// Calculating tile position based on the X and Z indices
				Vector3 tilePosition = new Vector3(this.gameObject.transform.position.x + xTileIndex * tileWidth, 
					this.gameObject.transform.position.y, 
					this.gameObject.transform.position.z + zTileIndex * tileDepth);
				// Create a new Tile
				GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity) as GameObject;
				// Generating the Tile texture
				tile.GetComponent<TileGeneration>().GenerateTile (centerVertexZ, maxDistanceZ);
			}
		}
	}
}
