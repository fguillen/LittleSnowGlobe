using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SnowSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject snowflakePrefab;
    [SerializeField] float snowflakeEachSeconds = 1f;
    [SerializeField] BoxCollider snowflakesZone;
    float nextSnowFlakeAt;

    void Start()
    {
        SpawnSnowflake();
    }

    void Update()
    {
        if(Time.time >= nextSnowFlakeAt)
            SpawnSnowflake();
    }

    void SpawnSnowflake()
    {
        Vector3 position = Utils.RandomPointInCollider(snowflakesZone);
        Instantiate(snowflakePrefab, position, Quaternion.identity, transform);
        nextSnowFlakeAt = Time.time + Utils.AddNoise(snowflakeEachSeconds);
    }
}
