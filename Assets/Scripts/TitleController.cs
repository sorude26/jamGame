using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    enum State
    {
        title,
        select
    }
    private State m_state = State.title;
    private GameObject m_titleobj;
    private GameObject m_selectobj;
    private GameObject m_button;
    private bool m_ready1 = false;
    private bool m_ready2 = false;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        m_titleobj = canvas.transform.Find("Title").gameObject;
        m_selectobj = canvas.transform.Find("Select").gameObject;
        m_button = m_selectobj.transform.Find("Button").gameObject;
        m_button.SetActive(false);
        StateChanger();
    }

    void Update()
    {
        if (m_state == State.select)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (m_ready1) { m_ready1 = false; }
                else { m_ready1 = true; }
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                if (m_ready2) { m_ready2 = false; }
                else { m_ready2 = true; }
            }
            if (m_ready1 && m_ready2)
            {
                m_button.SetActive(true);
            }
            else
            {
                m_button.SetActive(false);
            }
        }
        StateChanger();
    }

    private void StateChanger()
    {
        if (m_state == State.title)
        {
            m_titleobj.SetActive(true);
            m_selectobj.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_state = State.select;
            }
            return;
        }
        if (m_state == State.select)
        {
            m_titleobj.SetActive(false);
            m_selectobj.SetActive(true);
            return;
        }
    }
}
