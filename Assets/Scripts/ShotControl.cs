using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    [SerializeField] Shot m_shotPrefab;
    [SerializeField] string m_shotButton = "Shot";
    [SerializeField] Transform m_muzzle;
    [SerializeField] float m_shotInterval = 0.2f;
    [SerializeField] string m_shotName = "Player";
    float m_shotTimer = 0;
    private void Update()
    {
        if (Input.GetButton(m_shotButton))
        {
            m_shotTimer += Time.deltaTime;
            if (m_shotTimer >= m_shotInterval)
            {
                var shot = Instantiate(m_shotPrefab);
                shot.SetName(m_shotName);
                shot.transform.position = m_muzzle.position;
                shot.transform.rotation = this.transform.rotation;
                m_shotTimer = 0;
            }
        }
        else if(m_shotTimer != m_shotInterval)
        {
            m_shotTimer = m_shotInterval;
        }
    }
}
