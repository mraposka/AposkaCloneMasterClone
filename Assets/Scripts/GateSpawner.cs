using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GateSpawner : MonoBehaviour
{
    public GameObject startRange;
    public GameObject endRange;
    public GameObject gatePrefab;
    public GameObject trapPrefab;
    public GameObject enemyPrefab;
    public List<Vector3> spawnedObjects = new List<Vector3>();

    public float spawnRangeSpacing;
    [Range(0f, 1f)] public float gateChance;
    [Range(0f, 1f)] public float trapChance;
    [Range(0f, 1f)] public float enemyChance;
    float startRangePos;
    float endRangePos;
    void Start()
    {
        startRangePos = startRange.transform.position.z;
        endRangePos = endRange.transform.position.z;
    }
    void Update()
    {
        float spawnPos = Random.Range(startRangePos, endRangePos);
        if (spawnedObjects.Count == 0)
        {
            Instantiate(gatePrefab, new Vector3(-1.12f, -0.45f, spawnPos), Quaternion.identity);
            spawnedObjects.Add(new Vector3(-1.12f, -0.45f, spawnPos));
        }
        else if (spawnedObjects.Count < 15)
        {
            bool spawn = true;
            foreach (var obj in spawnedObjects)
            {
                float checkRangeFrom = obj.z - spawnRangeSpacing;
                float checkRangeTo = obj.z + spawnRangeSpacing;
                if (spawnPos > checkRangeFrom && spawnPos < checkRangeTo)
                { spawn = false; break; }
            }
            if (spawn)
            {
                float objectSelection = Random.Range(0.0f, 1f);//if <=cloneGateTrapChance = clonegate -- else = trap(%cloneGateTrapChance chance to be spawn trap)
                if (objectSelection <= gateChance)
                {
                    Instantiate(gatePrefab, new Vector3(-1.12f, -0.45f, spawnPos), Quaternion.identity);
                    spawnedObjects.Add(new Vector3(-1.12f, -0.45f, spawnPos));
                }
                else if (objectSelection >= gateChance && objectSelection <= trapChance)
                {
                    Instantiate(trapPrefab, new Vector3(-1.12f, 1.5f, spawnPos), Quaternion.identity);
                    spawnedObjects.Add(new Vector3(-1.12f, 1.5f, spawnPos));
                }
                else if (objectSelection >= trapChance && objectSelection <= enemyChance)
                {
                    Instantiate(enemyPrefab, new Vector3(0, 1.5f, spawnPos), Quaternion.identity);
                    spawnedObjects.Add(new Vector3(0, 1.5f, spawnPos));
                }
            }
        }

    }
}
