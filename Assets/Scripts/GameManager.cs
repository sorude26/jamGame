using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    bool m_check;
    [SerializeField] GameObject m_Draw;
    [SerializeField] FadeScript m_fade;
    [SerializeField] GameObject m_count;
    [SerializeField] SceneSwith m_sceneSwith;
    public bool Life { get; set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (m_Draw)
        {
            m_Draw.SetActive(false);
        }
        m_fade.StartFadeIn(GameStart);
    }
    void GameStart()
    {
        m_count.SetActive(true);
    }
    IEnumerator EndFade()
    {
        yield return new WaitForSeconds(5f);
        m_fade.StartFadeout(m_sceneSwith.OnClickStartButton);
    }
    public void GameSet()
    {
        if (m_check)
        {
            return;
        }
        StartCoroutine(GameEndCheck());
    }
    IEnumerator GameEndCheck()
    {
        m_check = true;
        yield return new WaitForSeconds(0.5f);
        EventManager.GameEnd();
        yield return new WaitForSeconds(0.5f);
        if (!Life)
        {
            if (m_Draw)
            {
                m_Draw.SetActive(true);
            }
        }
        EventManager.WinCheck();
        StartCoroutine(EndFade());
    }
}
