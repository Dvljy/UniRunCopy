using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScolling : MonoBehaviour
{
    private float width = 22.5f;
    Vector2 offset;
    void Update()
    {
        if (this.transform.position.x <= - width)
        {
            RePosition();
        }
    }
    
    void RePosition()
    {
        if (Random.Range(0,2) == 0)
        {
            offset.x += Random.Range(1, 4);
            offset = new Vector2(this.width * 2 + offset.x, 0);
            this.transform.position = (Vector2)this.transform.position + offset;
        }
        else
        {
            offset = new Vector2(this.width * 2, 0);
            this.transform.position = (Vector2)this.transform.position + offset;
        }
        
    }
}
