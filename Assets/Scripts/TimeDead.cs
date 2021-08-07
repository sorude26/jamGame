using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDead : MonoBehaviour
{
    [SerializeField] float m_lifeTime = 1f;
    [SerializeField] GameObject m_effect;
    float m_timer = 0;
    void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer >= m_lifeTime)
        {
            if (m_effect)
            {
                Instantiate(m_effect).transform.position = transform.position;
            }
            Destroy(gameObject);
        }
    }
}
