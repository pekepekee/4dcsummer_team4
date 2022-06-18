using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll: MonoBehaviour
{//スピードをインスペクターから選べる様にするよ！
    public float scrollSpeed = 1.0f;
    //float型をstartとendで宣言します。
    public float start;
    public float end;

    private void Update()
    {
        //スクロールの処理を計算。
        transform.Translate(-1 * scrollSpeed * Time.deltaTime, 0, 0);
        //スクロール終了の判定を新しく作った関数ScrollEndで参照します。
        if (transform.position.x <= end) ScrollEnd();
    }

    void ScrollEnd()
    {
        //スクロールした分だけ距離を戻します。
        transform.Translate(-1 * (end - start), 0, 0);

    }


}


