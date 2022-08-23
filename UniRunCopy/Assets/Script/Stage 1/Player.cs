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
    int currhp;
    int maxhp = 3;
    


    bool isGrounded = true;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playeraudio = GetComponent<AudioSource>();
        currhp = maxhp;
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
        if (currhp == 0)
        {
            GameManager.isDead = true;
        }
        PyColor.material.color = Color.red;
        playeraudio.clip = Die;
        playeraudio.Play();
        anim.enabled = false;
        GameManager.isDead = true;
    }

    private void FixedUpdate()
    {
        
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
            currhp--;
            Destroy(heart[0]);
        }
        if (other.tag == "Dead" && !GameManager.isDead)
        {
            PlayerDie();
        }
        
    }

}
