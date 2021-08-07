using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] int m_damage = 1;
    [SerializeField] string m_shotName = "default";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == m_shotName)
        {
            return;
        }
        IDamage target = collision.GetComponent<IDamage>();
        if (target != null)
        {
            target.Damage(m_damage);
        }
    }
    public void SetName(string shotName)
    {
        m_shotName = shotName;
    }
}