using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EscToExit : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        Observable.EveryUpdate()
            .Where(_ => Input.GetKey(KeyCode.Escape))
            .Subscribe(_ => ExitGame.ExitImm())
            .AddTo(this);
        ;
    }

}
