using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneChange : MonoBehaviour
{
    [SerializeField] FadeScript m_fade;
    [SerializeField] SceneSwith m_sceneSwith;
    bool m_frag;
    public void OnClickChange()
    {
        if (m_frag)
        {
            return;
        }
        m_frag = true;
        m_fade.StartFadeout(m_sceneSwith.OnClickStartButton);
        EffectManager.Instance.PlayEffect(EffectType.Hit, new Vector2(1000, 1000));
    }
}
