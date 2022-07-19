using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float JumpPower;

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
        //PlayerDie();
        
        

    }

    void PJ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < 2)
        {
            JumpCount++;

            rigid.velocity = Vector3.up * JumpPower;
            playeraudio.Play();


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

    /*void PD()
    {
        PyColor.material.color = Color.red;
        playeraudio.clip = Die;
        playeraudio.Play();
        isDead = true;
        Destroy(gameObject, 3f);
    }*/

    void PlayerDie()
    {
        PyColor.material.color = Color.red;
        playeraudio.clip = Die;
        playeraudio.Play();
        rigid.velocity = Vector2.zero;
        GameManager.isDead = true;
        Destroy(gameObject,3);
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
        if (other.tag == "Dead" && !GameManager.isDead)
        {
            PlayerDie();
        }
    }

}
