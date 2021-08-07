using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControl : MonoBehaviour,IDamage
{
    [SerializeField] int m_maxLife = 10;
    [SerializeField] Lifegage m_gage;
    public int Life { get; private set; }
    private void Start()
    {
        StartSet();
    }
    public virtual void Damage(int damage)
    {
        if (Life <= 0)
        {
            return;
        }
        Life -= damage;
        if (m_gage)
        {
            m_gage.ValueSet(m_maxLife, Life);
        }
        if (Life <= 0)
        {
            Dead();
        }
    }
    public virtual void Dead()
    {
        Destroy(this.gameObject);
    }
    protected virtual void StartSet()
    {
        Life = m_maxLife;
    }
}
