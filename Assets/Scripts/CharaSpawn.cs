using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint_1;
    [SerializeField] Transform spawnPoint_2;
    public GameObject spawn_point_p1;
    public GameObject spawn_point_p2;

    private void Start()
    {
        int angleR = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0, 0, angleR);
        Spawn();
    }
    
    
    public void Spawn()
    {
        Instantiate(spawn_point_p1).transform.position = spawnPoint_1.position;
        Instantiate(spawn_point_p2).transform.position = spawnPoint_2.position;
    }
}
