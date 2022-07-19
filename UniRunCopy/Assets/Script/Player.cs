using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float JumpPower;

    Rigidbody2D rigid;
    Animator anim;
    AudioSource playeraudio;
    public AudioClip Die;
    Renderer PyColor;

    int JumpCount;


    bool isGrounded = true;
    bool isDead = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playeraudio = GetComponent<AudioSource>();
    }



    void Update()
    {
        PJ();
        PlayerDie();
        if (isDead)
        {
            return;
        }

    }

    void PJ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < 1)
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
        playeraudio.clip = Die;
        playeraudio.Play();
        rigid.velocity = Vector2.zero;
        isDead = true;
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
        if (other.tag == "Dead" && !isDead)
        {
            PlayerDie();
        }
    }

}
