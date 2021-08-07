using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] int m_damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamage target = collision.GetComponent<IDamage>();
        if (target != null)
        {
            target.Damage(m_damage);
        }
    }
}