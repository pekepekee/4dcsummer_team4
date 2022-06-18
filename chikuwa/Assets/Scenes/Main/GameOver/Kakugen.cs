using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kakugen : MonoBehaviour
{
    public Text kakugen;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        i = Random.Range(0, 14);
        if(i == 0)
        {
            kakugen.text = "ちくわをのぞく時、ちくわもまたこちらをのぞいているのだ";
        }

        if (i == 1)
        {
            kakugen.text = "ちくわ大明神";
        }

        if (i == 2)
        {
            kakugen.text = "誰だ今の";
        }

        if (i == 3)
        {
            kakugen.text = "ちくわ入らずんばちくわ得ず";
        }

        if (i == 4)
        {
            kakugen.text = "そこのお前！\nちくわ1本あたりに含まれるスケトウダラはちくわ1本分だぜ";
        }

        if (i == 5)
        {
            kakugen.text = "今日僕はちくわの中をのぞいてしまった・・・";
        }

        if (i == 6)
        {
            kakugen.text = "ちくわ";
        }

        if(i == 7)
        {
            kakugen.text = "ちくわの中身をのぞいてしまった男の子の名前は\n田中奏生(たなかかなう)";
        }

        if(i == 8)
        {
            kakugen.text = "ちくわしかもってねぇ！！";
        }

        if (i == 9)
        {
            kakugen.text = "きみはどうあがいてもちくわ";
        }

        if (i == 10)
        {
            kakugen.text = "必殺・ちくわの穴から生クリーム光線";
        }

        if (i == 11)
        {
            kakugen.text = "鳥取県倉吉市にある喫茶店でちくわパフェが食べれる";
        }

        if (i == 12)
        {
            kakugen.text = "札幌市白石区どんぐり 本店がちくわパンの発祥地";
        }

        if (i == 13)
        {
            kakugen.text = "ちくわぶはちくわじゃない";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
