using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : LifeControl
{
    [SerializeField] private int m_bulletNum = 50;
    [SerializeField] private GameObject m_bullet;
    public override void Dead()
    {
        for (int i = 0; i < m_bulletNum; i++)
        {
            float random = Random.Range(0f, 360f);
            Instantiate(m_bullet, gameObject.transform.position, Quaternion.Euler(0, 0, random));
            EffectManager.Instance.PlayEffect(EffectType.Explosion1, transform.position);
        }
        base.Dead();
    }
}
