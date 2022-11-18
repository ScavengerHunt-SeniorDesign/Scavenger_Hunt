using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMapGeneration : MonoBehaviour 
{

	public float[,] GeneratePerlinNoiseMap(int mapDepth, int mapWidth, float scale, float offsetX, float offsetZ, Wave[] waves)
	{
		// Generate an empty noise map with the mapDepth and mapWidth coordinates
		float[,] noiseMap = new float[mapDepth, mapWidth];

		for (int zIndex = 0; zIndex < mapDepth; zIndex++) {
			for (int xIndex = 0; xIndex < mapWidth; xIndex++) {
				// Calculating sample indices based on the coordinates, the scale and the offset
				float sampleX = (xIndex + offsetX) / scale;
				float sampleZ = (zIndex + offsetZ) / scale;

				float noise = 0f;
				float normalization = 0f;
				foreach (Wave wave in waves)
				{
					// Create noise value using PerlinNoise for a given Wave
					noise += wave.amplitude * Mathf.PerlinNoise (sampleX * wave.frequency + wave.seed, sampleZ * wave.frequency + wave.seed);
					normalization += wave.amplitude;
				}
				// Normalize the noise value so that it is within 0 and 1 values
				noise /= normalization;

				noiseMap [zIndex, xIndex] = noise;
			}
		}

		return noiseMap;
	}

	public float[,] GenerateUniformNoiseMap(int mapDepth, int mapWidth, float centerVertexZ, float maxDistanceZ, float offsetZ) {
		// Creating an empty noise map with the mapDepth and mapWidth coordinates
		float[,] noiseMap = new float[mapDepth, mapWidth];

		for (int zIndex = 0; zIndex < mapDepth; zIndex++) {
			// Calculating sampleZ by summing the index and the offset
			float sampleZ = zIndex + offsetZ;
			// Calculating the noise proportional to the distance of the sample to the center of the level
			float noise = Mathf.Abs (sampleZ - centerVertexZ) / maxDistanceZ;

			// Applying noise pattern for all points with the Z coordinate
			for (int xIndex = 0; xIndex < mapWidth; xIndex++) {
				noiseMap [mapDepth - zIndex - 1, xIndex] = noise;
			}
		}

		return noiseMap;
	}
}

// Atrributes of a Wave class object
[System.Serializable]
public class Wave {
	public float seed;
	public float frequency;
	public float amplitude;
}
