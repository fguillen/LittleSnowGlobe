using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SnowSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject snowflakePrefab;
    [SerializeField] float snowflakeEachSeconds = 1f;
    [SerializeField] Collider2D snowflakesZone;
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
        RandomPointInCollider randomPointInCollider = new RandomPointInCollider(snowflakesZone);
        Vector3 position = randomPointInCollider.RandomPoint();
        Instantiate(snowflakePrefab, position, Quaternion.identity, transform);
        nextSnowFlakeAt = Time.time + Utils.AddNoise(snowflakeEachSeconds);
    }


}
