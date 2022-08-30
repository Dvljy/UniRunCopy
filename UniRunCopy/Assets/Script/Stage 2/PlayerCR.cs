using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCR : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer sprite;
    public AudioSource ad;
    public AudioClip ac;

    [SerializeField] float speed;
    float JumpCount = 2;
    bool isGrounded = true;
    


    void Start()
    {
        
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

    }

    void Jump()
    {
        if (Input.GetMouseButtonDown(0) && JumpCount < 2 && !GameManager.isDead)
        {
            ad.Play();
            JumpCount++;
            rigid.velocity = new Vector3(0, speed, 0);

        }
        else
        {


        }
        if (!isGrounded)
        {
            anim.SetBool("isJump", true);
        }
        else if (isGrounded)
        {
            anim.SetBool("isJump", false);
        }

    }

    void PD()
    {
        ad.clip = ac;
        ad.Play();
        anim.enabled = false;
        sprite.color = Color.red;
        Destroy(gameObject,0.3f);
    }

    void Damaged()
    {
        //부딪친 후 레이어 변경
        this.gameObject.layer = 7;
        //장애물과 부딪칠 시 색 변경
        sprite.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamaged",2);
    }

    void OffDamaged()
    {
        this.gameObject.layer = 6;
        sprite.color = new Color(1, 1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            JumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (transform.position.y > 0.1f)
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ttang")
        {
            Damaged();
            Heart.cur_hp--;
            if (Heart.cur_hp == 0)
            {
                PD();
                //GameManager.instance.isGameOver = true;
                GameManager.isDead = true;
                GameManager.instance.aud.enabled = false;
            }
            /*if (rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                Damaged();
            }*/
        }
        if (collision.tag == "Bronze")
        {
            GameManager.score += 1;
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Silver")
        {
            GameManager.score += 2;
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Gold")
        {
            GameManager.score += 4;
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Dead")
        {
            PD();
            GameManager.isDead = true;
            GameManager.instance.aud.enabled = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
