using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float JumpPower = 9;
    [SerializeField] private float MovePower = 5;
    public Rigidbody2D rb;
    public int JumpCount = 0;
    public int RightCount = 0;
    public int LeftCount = 1;
    public int MaxJump = 0;
    public AudioClip jump;
    public AudioClip item_get;
    public AudioClip damage;
    AudioSource As;
    public Transform target;

    public int hp = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        As = GetComponent<AudioSource>();
        
    }

    //　操作キャラクター変更メソッド
    


    // Update is called once per frame
    void Update()
    {
        target.transform.position = this.transform.position;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && LeftCount < 1)
        {
            transform.Translate(-10, 0, 0);     //左ワープ
            LeftCount++;
            RightCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && RightCount < 1)
        {
            transform.Translate(10, 0, 0);      //右ワープ
            RightCount++;
            LeftCount = 0;

        }


        this.rb.velocity = new Vector3(MovePower,GetComponent<Rigidbody2D>().velocity.y, 0);    //右移動

        if (JumpCount <= MaxJump)//  もし、Groundedがtrueなら、
        {
            if (Input.GetKeyDown(KeyCode.Space))//  もし、スペースキーがおされたなら、  
            {
                JumpCount++;//  Groundedをfalseにする
                rb.velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, JumpPower, 0);   //ジャンプ
                As.PlayOneShot(jump);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            JumpCount = 0;//  Groundedをtrueにする
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")//  もしItemというタグがついたオブジェクトに触れたら、
        {
            MaxJump++; //ジャンプ回数を増やす
            if(MaxJump == 3)
            {
                GetComponent<CharacterChange>().ChangeCharacter(0);
            }

            As.PlayOneShot(item_get);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Obstacle")//  もしObstacleというタグがついたオブジェクトに触れたら、
        {
            hp--;
            As.PlayOneShot(damage);
            Destroy(collision.gameObject);
            if (hp == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if(collision.gameObject.tag == "Animal")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
