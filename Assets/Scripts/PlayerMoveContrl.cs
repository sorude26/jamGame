using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMoveContrl : MoveControl
{
    [SerializeField] string m_inputHname = "Horizontal";
    [SerializeField] string m_inputVname = "Vertical";
    [SerializeField] float m_moveSpeed = 1f;
    bool m_move;
    Rigidbody2D m_rB;
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
        float x = Input.GetAxisRaw(m_inputHname);
        float y = Input.GetAxisRaw(m_inputVname);
        m_rB.velocity = new Vector2(x, y).normalized * m_moveSpeed;
    }
    
    public override void GameEnd()
    {
        m_move = false;
    }
}
