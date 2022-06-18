using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class HideCredit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            .Subscribe(_ =>
                GameObject.Find("Credit").GetComponent<SpriteRenderer>().enabled = false
            )
            .AddTo(this)
            ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
