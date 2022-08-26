using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    private float width = 7.5f;

    void Update()
    {
        if (this.transform.position.x <= -width)
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
