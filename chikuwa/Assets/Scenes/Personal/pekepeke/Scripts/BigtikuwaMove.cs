using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BigtikuwaMove : MonoBehaviour
{
    [SerializeField] private float JumpPower = 9;
    [SerializeField] private float MovePower = 5;
    public Rigidbody2D rb;
    public int JumpCount = 0;
    public int RightCount = 0;
    public int LeftCount = 1;
    public int MaxJump = 3;
    public AudioClip jump;
    public AudioClip item_get;
    public AudioClip damage;
    AudioSource As;
    public int hp = 10;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        As = GetComponent<AudioSource>();
}

    



    // Update is called once per frame
    void Update()
    {
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


        this.rb.velocity = new Vector3(MovePower, GetComponent<Rigidbody2D>().velocity.y, 0);    //右移動

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

        if (collision.gameObject.tag == "Animal")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
