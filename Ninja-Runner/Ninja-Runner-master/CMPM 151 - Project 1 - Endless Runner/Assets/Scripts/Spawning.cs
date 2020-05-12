using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject WallPrefab;
    public Vector3 center;
    public Vector3 size;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWall", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            SpawnWall();
        }
    }

    public void SpawnWall()
    {
        float first = Random.Range(-size.y / 2, size.y / 2);
        Vector3 pos1 = center + new Vector3(1, first, -5);   //only the y axis has a random range
       // Vector3 pos2 = center + new Vector3(1, first - 19, -5);   //only the y axis has a random range
        Instantiate(WallPrefab, pos1, Quaternion.identity);
       // Instantiate(WallPrefab, pos2, Quaternion.identity);
    }
}
