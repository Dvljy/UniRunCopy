using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCR : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float speed;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    
}
