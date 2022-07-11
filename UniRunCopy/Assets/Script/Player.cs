using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float JumpPower;

    Rigidbody2D rigid;
    Animation anim;

    bool isJump = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        
    }

    void Update()
    {
        PJ();
        
    }

    void PJ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
            rigid.AddForce(Vector3.up * JumpPower, ForceMode2D.Impulse);
              
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
