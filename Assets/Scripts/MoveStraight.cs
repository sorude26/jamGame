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
        m_move = true;
    }

    void Update()
    {
        if (!m_move)
        {
            m_vec = Vector2.zero;
        }
        m_rb.velocity = new Vector2(m_vec.x * m_speed, m_vec.y * m_speed);
    }

    public override void GameEnd()
    {
        throw new System.NotImplementedException();
    }
}
