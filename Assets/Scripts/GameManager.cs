using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    bool m_check;
    public bool Life { get; set; }
    private void Awake()
    {
        Instance = this;
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
            Debug.Log("引き分け");
        }
    }
}
