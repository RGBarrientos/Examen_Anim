using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn; 
    [SerializeField]
    private int numberOfObjects = 10; 

    private Terrain terrain;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        SpawnObjects();
    }

    void SpawnObjects()
    {
        // Obtener el tamaño del terreno
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;

        for (int i = 0; i < numberOfObjects; i++)
        {
            // Generar una posición aleatoria en el terreno
            float x = Random.Range(0, terrainWidth);
            float z = Random.Range(0, terrainLength);
            float y = terrain.SampleHeight(new Vector3(x, 0, z));

            Vector3 spawnPosition = new Vector3(x, y, z);

            // Generar el objeto en la posición aleatoria
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}

