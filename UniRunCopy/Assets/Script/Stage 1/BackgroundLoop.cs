using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;



    void Awake()
    {
        BoxCollider2D backgroundColider = GetComponent<BoxCollider2D>();
        width = backgroundColider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width)
        {
            Reposition();
        }

    }

    void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }

}
