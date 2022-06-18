using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAtariHantei : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "TestChikuwa")
        {
            //TestChikuwaに当たるとConsole欄にヒットというデバッグメッセージが出るようになっています
            Debug.Log("ヒット");
        }
    }
}
