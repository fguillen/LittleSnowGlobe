using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SnowSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject snowflakePrefab;
    [SerializeField] float snowflakeEachSeconds = 1f;
    [SerializeField] int initialSnowflakes = 100;
    [SerializeField] float initialImpulseForce = 1f;
    [SerializeField] BoxCollider snowflakesZone;
    float nextSnowFlakeAt;

    void Start()
    {
        for (int i = 0; i < initialSnowflakes; i++)
        {
            SpawnSnowflake();
        }
    }

    void Update()
    {
        if(Time.time >= nextSnowFlakeAt)
            SpawnSnowflake();
    }

    void SpawnSnowflake()
    {
        Vector3 position = Utils.RandomPointInCollider(snowflakesZone);
        GameObject snowflake = Instantiate(snowflakePrefab, position, Quaternion.identity, transform);
        float force = Utils.AddNoise(initialImpulseForce);
        snowflake.GetComponent<Rigidbody>().AddForce(Vector3.down * force, ForceMode.Impulse);
        nextSnowFlakeAt = Time.time + Utils.AddNoise(snowflakeEachSeconds);
    }
}
