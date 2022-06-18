using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class AnimalCallingPinch : MonoBehaviour
{
    [SerializeField] private ChikuwaHitPoint chikuwaHp;

    [SerializeField] private AnimalMove animalMove;

    // Start is called before the first frame update
    void Start()
    {
        if (chikuwaHp == null) Debug.LogError("ChikuwaHp is null");

        chikuwaHp
            .CurrentHitPoint
            .Zip(chikuwaHp.CurrentHitPoint.Skip(1), (Old, New) => new { Old, New })
            .Where(z => z.Old - z.New == 1)
            .Do(z => Debug.Log(z.New + ", " + z.Old))
            .Subscribe(_ => animalMove.Pinch(animalMove.timer, animalMove.pos))
            .AddTo(this)
            ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
