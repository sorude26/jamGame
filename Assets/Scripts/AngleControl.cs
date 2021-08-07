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
        transform.up = new Vector2(x, y).normalized;
    }
}
