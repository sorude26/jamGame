using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaObject : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GameArea")
        {
            Destroy(this.gameObject);
        }
    }
}
