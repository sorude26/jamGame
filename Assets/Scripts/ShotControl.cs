using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    [SerializeField] Shot m_shotPrefab;
    [SerializeField] string m_shotButton = "Shot";
    [SerializeField] Transform m_muzzle;
    [SerializeField] float m_shotInterval = 0.2f;
    [SerializeField] GameObject m_owner;
    string m_shotName = "Player";
    float m_shotTimer = 0;
    bool m_shot;
    private void Start()
    {
        m_shotName = m_owner.name;
        EventManager.OnGameStart += StartShot;
        EventManager.OnGameEnd += ShotStop;
    }
    private void Update()
    {
        if (!m_shot)
        {
            return;
        }
        if (m_shotTimer < m_shotInterval)
        {
            m_shotTimer += Time.deltaTime;
        }
        if (Input.GetButton(m_shotButton))
        {
            if (m_shotTimer >= m_shotInterval)
            {
                var shot = Instantiate(m_shotPrefab);
                shot.SetName(m_shotName);
                shot.transform.position = m_muzzle.position;
                shot.transform.rotation = this.transform.rotation;
                m_shotTimer = 0;
            }
        }
    }
    void StartShot()
    {
        m_shot = true;
        EventManager.OnGameStart -= StartShot;
    }
    public void ShotStop()
    {
        m_shot = false;
        EventManager.OnGameEnd -= ShotStop;
    }
}
