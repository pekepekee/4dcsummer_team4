using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SmallChikuwaHpAsGlue : MonoBehaviour
{
    [SerializeField] private CharacterMove SmallChikuwaStatus;

    [SerializeField] private ChikuwaHitPoint ChikuwaHp;

    // Start is called before the first frame update
    void Start()
    {
        if (SmallChikuwaStatus == null) Debug.LogError("SmallChikuwaStatus is null");

        if (ChikuwaHp== null) Debug.LogError("ChikuwaHp is null");

        ChikuwaHp._maxHitPoint.Value = SmallChikuwaStatus.hp;

        SmallChikuwaStatus
            .ObserveEveryValueChanged(s => s.hp)
            .Subscribe(hp => ChikuwaHp._currentHitPoint.Value = hp)
            .AddTo(this);
            ;
    }

}
