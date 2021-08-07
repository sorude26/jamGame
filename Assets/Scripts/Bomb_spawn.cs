using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_spawn : MonoBehaviour
{
    [SerializeField] Transform[] m_spawnPoint;
    [SerializeField] GameObject spawn_bomb;
    float m_timer = 0.0F;
    [SerializeField] float m_spawnTime = 5.0F;
    [SerializeField] float m_sapawnminTime = 2.0F;
    [SerializeField] float m_speedUpSpeed = 0.5F;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        m_timer +=  Time.deltaTime;
        if(m_timer >= m_spawnTime)
        {
            Spawn();
            m_timer = 0;
            if(m_sapawnminTime <= m_spawnTime) m_spawnTime -= m_speedUpSpeed;
        }
    }
    public void Spawn()
    {
        int tR = Random.Range(0, m_spawnPoint.Length);
        Instantiate(spawn_bomb.transform).position = m_spawnPoint[tR].position;
    }
}
