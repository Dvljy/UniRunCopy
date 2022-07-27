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
            Debug.Log($"입력하신 점수는 {userInput}은(는) A 학점 입니다.");
        }
        else if (a >= 80)
        {
            Debug.Log($"입력하신 점수는 {userInput}은(는) B 학점 입니다.");
        }
        else
        {
            if (a >= 70)
            {
                Debug.Log($"입력하신 점수는 {userInput}은(는) C 학점 입니다.");
            }
            else if(a <= 69)
            {
                Debug.Log($"입력하신 점수는 {userInput}은(는) D 학점 입니다.");
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
