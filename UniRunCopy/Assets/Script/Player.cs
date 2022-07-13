using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float JumpPower;

    Rigidbody2D rigid;
    Animator anim;
    AudioSource playeraudio;
    AudioClip Jumpaudio;
    Renderer PyColor;

    int JumpCount;

    bool isJump = false;
    bool isGrounded = true;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playeraudio = GetComponent<AudioSource>();
    }



    void Update()
    {
        PJ();
        //Die();


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
            JumpCount = 0;
            anim.SetBool("isJump", false);
            anim.SetBool("isGrounded", true);
        }
        else
        {
            anim.SetBool("isJump", true);
            anim.SetBool("isGrounded", false);
        }

    }

    /*void Die()
    {
        if (true)
        {
            PyColor.material.color = Color.red;

            Destroy(gameObject, 3f);
        }
        
    }*/


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
