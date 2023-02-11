using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public float spawnTime = 1f;
    private float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        if(timer > spawnTime)
        {
            int rand = Random.Range(0, obstaclePrefab.Length);

            GameObject obs = Instantiate(obstaclePrefab[rand]);
            obs.transform.position = transform.position + new Vector3(0, 0, 0);
            Destroy(obs, 15);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
