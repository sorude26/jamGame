using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DScripts : MonoBehaviour
{
    public void DGameObject()
    {
        EventManager.GameStart();
        Destroy(this.gameObject);
    }
    public void Count()
    {
        EffectManager.Instance.PlayEffect(EffectType.BottonOn, new Vector2(1000, 1000));
    }
    public void Go()
    {
        EffectManager.Instance.PlayEffect(EffectType.Hanabi2, Vector2.zero);
    }
}
