﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeControl : LifeControl
{
    [SerializeField] GameObject m_effect;
    private void OnEnable()
    {
        EventManager.OnGameEnd += Call;
    }
    private void OnDisable()
    {
        EventManager.OnGameEnd -= Call;
    }
    public override void Damage(int damage)
    {
        if (m_effect)
        {
            Instantiate(m_effect).transform.position = this.transform.position;
        }
        base.Damage(damage);
    }
    public override void Dead()
    {
        GameManager.Instance.GameSet();
        Destroy(this.gameObject);
    }
    public void Call()
    {
        GameManager.Instance.Life = true;
        Debug.Log(this.gameObject.name + "Win!");
    }
}
