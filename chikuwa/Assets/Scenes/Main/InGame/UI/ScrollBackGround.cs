using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScrollBackGround : MonoBehaviour
{
    [SerializeField] private GameObject BackGround;

    private Sequence scroll;

    // Start is called before the first frame update
    void Start()
    {
        scroll = DOTween.Sequence()
            .SetEase(Ease.Linear)
            .Append(transform.DOLocalMoveX(-8.9f, 5))
            .AppendCallback(() =>
            {
                Instantiate(BackGround).GetComponent<ScrollBackGround>().BackGround = BackGround;
                Destroy(gameObject);
            }
            )
            .SetAutoKill(false)
            .SetLink(gameObject)
            .Pause()
            ;

        scroll.Restart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
