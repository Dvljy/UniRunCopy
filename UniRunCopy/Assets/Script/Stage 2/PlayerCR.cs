using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCR : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer sprite;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {

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
        sprite.color = Color.red;
        Destroy(gameObject);
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
            PD();

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
