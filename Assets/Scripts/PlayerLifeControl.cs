using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeControl : LifeControl
{
    [SerializeField] GameObject m_winPanel;
    protected override void StartSet()
    {
        if (m_winPanel)
        {
            m_winPanel.SetActive(false);
        }
        base.StartSet();
    }
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
        EffectManager.Instance.PlayEffect(EffectType.Hit, transform.position);
        base.Damage(damage);
    }
    public override void Dead()
    {
        EffectManager.Instance.PlayEffect(EffectType.Explosion2, transform.position);
        GameManager.Instance.GameSet();
        Destroy(this.gameObject);
    }
    public void Call()
    {
        GameManager.Instance.Life = true;
        EventManager.OnWinCheck += WinCheck;
    }
    public void WinCheck()
    {
        if (m_winPanel)
        {
            m_winPanel.SetActive(true);
        }
        EventManager.OnWinCheck -= WinCheck;
    }
}
