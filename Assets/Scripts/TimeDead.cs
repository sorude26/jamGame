using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDead : MonoBehaviour
{
    [SerializeField] float m_lifeTime = 1f;
    float m_timer = 0;
    void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer >= m_lifeTime)
        {
            EffectManager.Instance.PlayEffect(EffectType.Explosion, transform.position);
            Destroy(gameObject);
        }
    }
}
