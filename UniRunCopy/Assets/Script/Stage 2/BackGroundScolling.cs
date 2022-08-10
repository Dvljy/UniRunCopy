using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScolling : MonoBehaviour
{
    private float width = 22.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= - width)
        {
            RePosition();
        }
    }
    
    void RePosition()
    {
        Vector2 offset = new Vector2(this.width * 2, 0);
        this.transform.position = (Vector2)this.transform.position + offset;
    }
}
