using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControl : MonoBehaviour,IDamage
{
    [SerializeField] int m_maxLife = 10;
    public int Life { get; private set; }
    private void Start()
    {
        Life = m_maxLife;
    }
    public virtual void Damage(int damage)
    {
        if (Life <= 0)
        {
            return;
        }
        Life -= damage;
        if (Life <= 0)
        {
            Dead();
        }
    }
    public virtual void Dead()
    {
        Destroy(this.gameObject);
    }
}
