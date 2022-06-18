using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMove : MonoBehaviour
{
    [SerializeField] float InitPosition; //初期位置
    [SerializeField] float InitVelocity; //初速度
    [SerializeField] float PinchVelocity; //ピンチの時の速度
    [SerializeField] float BackVelocity; //ピンチから戻る時の速度
    [SerializeField] public float timer;　//ピンチの時右に行く時間
    [SerializeField] public float pos;    //ピンチのときこれ以上右に行かないようにする位置
    [SerializeField] public float backpos; //ピンチの後に戻る位置、
    public float pinchfaze = 0;//caseの推移に使います。この値が変わるとcaseが推移し動作が変わります。
    public float pinchtime = 0;//ピンチになったとき、時間を計測するのに使います。
    //効果音関連
    public AudioClip soundBark;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //初期位置を決めます。
        transform.position = new Vector3(InitPosition, 0, 0);

        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        switch (pinchfaze)
        {
            //初速がある時の動き、初速0の時は何もしません。
            case 0:
                transform.position += new Vector3(InitVelocity, 0, 0) * Time.deltaTime;
                break;
            //ピンチ時、右に圧迫する動き、位置がpos以上になるとcase2、timer秒経つとcase3に移行します。
            case 1:
                transform.position += new Vector3(PinchVelocity, 0, 0) * Time.deltaTime;
                pinchtime += Time.deltaTime;
                if (transform.position.x >= pos)
                {
                    pinchfaze = 2;
                }
                if (pinchtime >= timer)
                {
                    pinchfaze = 3;
                }
                break;
            //timer秒経つまで待機します。timer秒経つとcase3に移行します。
            case 2:
                pinchtime += Time.deltaTime;
                if (pinchtime >= timer)
                {
                    pinchfaze = 3;
                }
                break;
            //BackVelocityの速度でbackposの位置に戻ります。戻るとcase4に移行します。
            case 3:
                transform.position -= new Vector3(BackVelocity, 0, 0) * Time.deltaTime;
                if (transform.position.x <= backpos)
                {
                    pinchfaze = 4;
                }
                break;
            //値をリセットします。
            case 4:
                pinchfaze = 0;
                pinchtime = 0;
                break;
            default:
                break;

        }
    }
    public void Pinch(float timer, float pos)//これが呼び出されたときピンチでなければピンチ時の動きをします。
    {
        if (pinchfaze == 0)
        {
            pinchfaze = 1;

            audioSource.PlayOneShot(soundBark);
        }

    }
}
