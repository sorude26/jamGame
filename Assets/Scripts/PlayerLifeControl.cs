using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeControl : LifeControl
{
    private void OnEnable()
    {
        EventManager.OnGameEnd += Call;
    }
    private void OnDisable()
    {
        EventManager.OnGameEnd -= Call;
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
