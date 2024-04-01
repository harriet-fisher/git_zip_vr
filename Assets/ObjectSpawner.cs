using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public int numberOfObjectsToSpawn = 3;
    public float terrainWidth = 100f;
    public float terrainLength = 100f;
    public float yOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomObjects();
    }

    void SpawnRandomObjects()
    {
        Object[] objects = Resources.LoadAll("findable_objects", typeof(GameObject));

        if (objects.Length == 0)
        {
            Debug.LogError("No objects found in 'findable_objects' folder.");
            return;
        }

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            GameObject objToSpawn = (GameObject)objects[Random.Range(0, objects.Length)];
            Vector3 spawnPosition = GetRandomPosition();
            Instantiate(objToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-terrainWidth / 2, terrainWidth / 2);
        float z = Random.Range(-terrainLength / 2, terrainLength / 2);
        float y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z)) + yOffset;
        return new Vector3(x, y, z);
    }
}

