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
        /*string userInput = "55";
        int a = int.Parse(userInput);

        if (a >= 90)
        {
            Debug.Log($"�Է��Ͻ� ������ {userInput}��(��) A ���� �Դϴ�.");
        }
        else if (a >= 80)
        {
            Debug.Log($"�Է��Ͻ� ������ {userInput}��(��) B ���� �Դϴ�.");
        }
        else
        {
            if (a >= 70)
            {
                Debug.Log($"�Է��Ͻ� ������ {userInput}��(��) C ���� �Դϴ�.");
            }
            else if(a <= 69)
            {
                Debug.Log($"�Է��Ͻ� ������ {userInput}��(��) D ���� �Դϴ�.");
            }
        }*/
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
