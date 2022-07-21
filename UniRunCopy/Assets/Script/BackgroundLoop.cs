using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;

    

    void Awake()
    {
        BoxCollider2D BoxCollider = GetComponent<BoxCollider2D>();
        width = BoxCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -25)
        {
            Reposition();
        }

    }

    void Reposition()
    {
        Vector2 offset = new Vector2(25, 0);
        transform.position = (Vector2)transform.position + offset;
    }

}
