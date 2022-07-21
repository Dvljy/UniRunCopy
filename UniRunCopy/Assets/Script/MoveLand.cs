using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLand : MonoBehaviour
{
    [SerializeField] float speed = 10;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
