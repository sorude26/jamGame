using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMove : MoveControl
{
    /// <summary>移動速度</summary>
    [SerializeField] private float m_speed = 5f;
    private Rigidbody2D m_rb;
    private bool m_move;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_move = true;
    }

    void Update()
    {
        if (!m_move)
        {
            m_rb.velocity = Vector2.zero;
        }
        else
        {
            m_rb.velocity = transform.up * m_speed;
        }
    }

    public override void GameEnd()
    {
        throw new System.NotImplementedException();
    }
}
