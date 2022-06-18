using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BigChikuwaHpAsGlue : MonoBehaviour
{
    [SerializeField] private BigtikuwaMove BigChikuwaStatus;

    [SerializeField] private ChikuwaHitPoint ChikuwaHp;

    // Start is called before the first frame update
    void Start()
    {
        if (BigChikuwaStatus == null) Debug.LogError("BigChikuwaStatus is null");

        if (ChikuwaHp== null) Debug.LogError("ChikuwaHp is null");

        ChikuwaHp._maxHitPoint.Value = BigChikuwaStatus.hp;

        BigChikuwaStatus
            .ObserveEveryValueChanged(b => b.hp)
            .Subscribe(hp => ChikuwaHp._currentHitPoint.Value = hp)
            .AddTo(this)
            ;
    }

}
