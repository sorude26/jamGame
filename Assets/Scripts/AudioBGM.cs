using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioBGM : MonoBehaviour
{
    private AudioSource m_as;
    [SerializeField] private AudioClip m_start;
    [SerializeField] private AudioClip m_battle;
    [SerializeField] private AudioClip m_win;
    void Start()
    {
        m_as = GetComponent<AudioSource>();
        Battle();
    }

    private void OnEnable()
    {
        EventManager.OnGameEnd += Win;
    }
    private void OnDisable()
    {
        EventManager.OnGameEnd -= Win;
    }

    public void Battle()
    {
        m_as.clip = m_battle;
        m_as.Play();
    }

    public void Win()
    {
        m_as.clip = m_win;
        m_as.Play();
    }
}