using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMoveContrl : MoveControl
{
    [SerializeField] string m_inputHname = "Horizontal";
    [SerializeField] string m_inputVname = "Vertical";
    [SerializeField] float m_moveSpeed = 1f;
    [SerializeField] GameObject m_shot = default;
    bool m_move;
    Rigidbody2D m_rB;
    float m_h = 0f;
    float m_lastHorizontalInput = 1f;
    private void Start()
    {
        m_rB = GetComponent<Rigidbody2D>();
        m_move = true;
    }
    void Update()
    {
        if (!m_move)
        {
            m_rB.velocity = Vector2.zero;
            return;
        }
        m_h = Input.GetAxisRaw(m_inputHname);
        float v = Input.GetAxisRaw(m_inputVname);
        FlipX(m_h);
        m_rB.velocity = new Vector2(m_h, v).normalized * m_moveSpeed;
    }
    
    public override void GameEnd()
    {
        m_move = false;
    }
    void FlipX(float horizontalInput)
    {
        if (horizontalInput != 0)
        {
            if (horizontalInput * m_lastHorizontalInput < 0f)
            {
                Vector3 scale = this.transform.localScale;
                scale.x *= -1;
                this.transform.localScale = scale;
                m_shot.transform.localScale = scale;
            }
            m_lastHorizontalInput = m_h;
        }
    }
}
