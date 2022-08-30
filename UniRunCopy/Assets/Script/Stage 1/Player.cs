using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float JumpPower;
    [SerializeField] GameObject[] heart;
    [SerializeField] GameObject panel;

    Rigidbody2D rigid;
    Animator anim;
    AudioSource playeraudio;
    [SerializeField] SpriteRenderer PyColor;
    public AudioClip Die;

    int JumpCount;




    bool isGrounded = true;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playeraudio = GetComponent<AudioSource>();

    }



    void Update()
    {
        if (GameManager.isDead)
            return;
        PJ();
    }

    void PJ()
    {
        if (Input.GetMouseButtonDown(0) && JumpCount < 2 && !panel.activeSelf)
        {
            JumpCount++;

            rigid.velocity = Vector3.up * JumpPower;
            playeraudio.Play();


        }
        else if (Input.GetMouseButtonDown(0) && rigid.velocity.y > 0 && panel.activeSelf)
        {
            rigid.velocity = rigid.velocity * 0.5f;
        }

        if (isGrounded)
        {

            anim.SetBool("isJump", false);
            anim.SetBool("isGrounded", true);
        }
        else
        {
            anim.SetBool("isJump", true);
            anim.SetBool("isGrounded", false);
        }


    }


    public void PlayerDie()
    {
        if (Heart.cur_hp == 0)
        {
            GameManager.isDead = true;
        }
        PyColor.material.color = Color.red;
        playeraudio.clip = Die;
        playeraudio.Play();
        anim.enabled = false;
        GameManager.isDead = true;
    }

    void Damaged()
    {
        //부딪친 후 레이어 변경
        this.gameObject.layer = 7;
        //장애물과 부딪칠 시 색 변경
        PyColor.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamaged", 2);
    }

    void OffDamaged()
    {
        this.gameObject.layer = 6;
        PyColor.color = new Color(1, 1, 1, 1);
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
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "obstacles")
        {
            Damaged();
            Heart.cur_hp--;
            if (Heart.cur_hp == 0)
            {
                PlayerDie();
                //GameManager.instance.isGameOver = true;
                GameManager.isDead = true;
                GameManager.instance.aud.enabled = false;
            }
        }
        if (other.tag == "Bronze")
        {
            GameManager.score += 1;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Silver")
        {
            GameManager.score += 2;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Gold")
        {
            GameManager.score += 4;
            other.gameObject.SetActive(false);
        }
        if (other.tag == "Dead" && !GameManager.isDead)
        {
            PlayerDie();
        }
        

    }

}


