using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : MoveControl
{
    /// <summary>進行方向</summary>
    [SerializeField] public Vector2 m_vec;
    /// <summary>移動速度</summary>
    [SerializeField] private float m_speed = 5f;
    private Rigidbody2D m_rb;
    private bool m_move;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_vec.Normalize();

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
            m_rb.velocity = new Vector2(m_vec.x * m_speed, m_vec.y * m_speed);
        }
    }

    public override void GameEnd()
    {
        m_move = false;
    }
    public void SetDir(Vector2 dir)
    {
        m_vec = dir.normalized;
    }
}
