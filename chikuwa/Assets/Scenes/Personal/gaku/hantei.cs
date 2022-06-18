using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hantei: MonoBehaviour
{
    public string target_tag;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == target_tag)
        {
   
            Destroy(gameObject);
        }
    }
}
