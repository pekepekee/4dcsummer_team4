using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public class HpGauge : MonoBehaviour
{
    [SerializeField] private ChikuwaHitPoint chikuwaHp;

    [SerializeField] private GameObject chikuwaLife;

    [SerializeField] private Vector3 initHpShow;

    [SerializeField] private Vector3 showStep;

    private List<GameObject> HpLifes;

    // Start is called before the first frame update
    void Start()
    {
        if (chikuwaHp == null) Debug.LogError("chikuwaHp null");

        if (chikuwaLife== null) Debug.LogError("chikuwaLife null");


        HpLifes = new List<GameObject>();

        for(int i = 0; i < 10; i++)
        {
            var cw = Instantiate(chikuwaLife);
            cw.transform.position = initHpShow + showStep * i;
            cw.GetComponent<SpriteRenderer>().enabled = true;

            HpLifes.Add(cw);
        }

        chikuwaHp
            .MaxHitPoint
            .Subscribe(n =>
            {
                for (int i = 0; i < n; i++)
                {
                    HpLifes[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                for(int i = n; i < HpLifes.Count; i++)
                {
                    HpLifes[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            )
            .AddTo(this)
            ;


        chikuwaHp
            .CurrentHitPoint
            .Subscribe(n =>
            {
                for (int i = 0; i < n; i++)
                {
                    HpLifes[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                for(int i = n; i < HpLifes.Count; i++)
                {
                    HpLifes[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            )
            .AddTo(this)
            ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
