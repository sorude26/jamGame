using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleControl : MonoBehaviour
{
    [SerializeField] string m_inputHname = "Horizontal";
    [SerializeField] string m_inputVname = "Vertical";
    void Update()
    {
        float x = Input.GetAxisRaw(m_inputHname);
        float y = Input.GetAxisRaw(m_inputVname);
        Vector2 dir = new Vector2(x, y);
        if (dir == Vector2.zero)
        {
            transform.up = Vector2.right * transform.localScale;
        }
        else
        {
            transform.up = dir.normalized;
        }
    }
}
