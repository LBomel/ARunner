using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_spawner_behavior : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] float min = 1;
    [SerializeField] float max = 10;

    void Start()
    {
        Invoke("obstacleSpawn", 1f);       
    }

    void Update()
    {
    }


    private void obstacleSpawn()
    {
        float rand = Random.Range(min, max);
        Instantiate(obstacle, gameObject.transform);
        Invoke("obstacleSpawn", rand);
    }
}
