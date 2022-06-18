using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ChikuwaHitPoint : MonoBehaviour
{
    public IntReactiveProperty _maxHitPoint;

    public IntReactiveProperty _currentHitPoint;

    public IReadOnlyReactiveProperty<int> CurrentHitPoint => _currentHitPoint;

    public IReadOnlyReactiveProperty<int> MaxHitPoint => _maxHitPoint;

    private void Awake()
    {
        _maxHitPoint = new IntReactiveProperty();

        _currentHitPoint = new IntReactiveProperty();

        /*
        CurrentHitPoint = _currentHitPoint
            .Where(hp => hp < _maxHitPoint.Value)
            .Do(_ => Debug.Log("debug: " + _maxHitPoint.Value))
            .ToReadOnlyReactiveProperty<int>();
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHitPoint.Subscribe(_ => Debug.Log("Changed: " + _));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
