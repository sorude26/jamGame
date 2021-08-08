using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] Transform m_startPos;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GameArea")
        {
            transform.position = m_startPos.position;
        }
    }
}
