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
    private GameObject m_titleAnim;
    private GameObject m_select1;
    private GameObject m_ok1;
    private GameObject m_select2;
    private GameObject m_ok2;
    private bool m_ready1 = false;
    private bool m_ready2 = false;
    private bool m_trigger = false;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        m_titleobj = canvas.transform.Find("Title").gameObject;
        m_selectobj = canvas.transform.Find("Select").gameObject;
        GameObject image = m_selectobj.transform.Find("Image").gameObject;
        m_select1 = image.transform.Find("setting").gameObject;
        m_ok1 = image.transform.Find("ok").gameObject;
        m_ok1.SetActive(false);
        image = m_selectobj.transform.Find("Image (2)").gameObject;
        m_select2 = image.transform.Find("setting").gameObject;
        m_ok2 = image.transform.Find("ok").gameObject;
        m_ok2.SetActive(false);
        m_button = m_selectobj.transform.Find("Button").gameObject;
        m_button.SetActive(false);
        m_titleAnim = GameObject.Find("TitleAnim");

        StateChanger();
    }

    void Update()
    {
        if (m_state == State.select)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (m_ready1) 
                { 
                    m_ready1 = false;
                    m_select1.SetActive(true);
                    m_ok1.SetActive(false);
                }
                else 
                {
                    m_ready1 = true;
                    m_select1.SetActive(false);
                    m_ok1.SetActive(true);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                if (m_ready2) 
                { 
                    m_ready2 = false;
                    m_select2.SetActive(true);
                    m_ok2.SetActive(false);
                }
                else
                { 
                    m_ready2 = true;
                    m_select2.SetActive(false);
                    m_ok2.SetActive(true);
                }
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
            return;
        }
        if (m_state == State.select)
        {
            m_titleobj.SetActive(false);
            m_selectobj.SetActive(true);
            m_titleAnim.SetActive(false);
            return;
        }
    }

    public void OnClick()
    {
        m_state = State.select;
    }
}
