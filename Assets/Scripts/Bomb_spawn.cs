using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_spawn : MonoBehaviour
{
    [SerializeField] Transform[] m_spawnPoint;
    [SerializeField] MoveStraight spawn_bomb;
    float m_timer = 0.0F;
    [SerializeField] float m_spawnTime = 5.0F;
    [SerializeField] float m_sapawnminTime = 2.0F;
    [SerializeField] float m_speedUpSpeed = 0.5F;
    bool m_spawn;
    void Start()
    {
        m_spawn = true;
        EventManager.OnGameEnd += SpawnStop;
    }

    void Update()
    {
        if (!m_spawn)
        {
            return;
        }
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
        int p = Random.Range(0, m_spawnPoint.Length);
        int x = Random.Range(-1, 2);
        int y = Random.Range(-1, 2);
        var bom = Instantiate(spawn_bomb);
        bom.SetDir(new Vector2(x, y));
        bom.gameObject.transform.position = m_spawnPoint[p].position;
    }
    private void SpawnStop()
    {
        m_spawn = false;
        EventManager.OnGameEnd -= SpawnStop;
    }
}
