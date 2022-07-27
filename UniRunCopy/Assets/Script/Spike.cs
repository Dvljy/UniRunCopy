using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;




    int a;



    void Start()
    {
        a = Random.Range(0, 3);
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (a == 0)
            {
                obstacles[i].SetActive(true);
                a = Random.Range(0, 3);

            }
            else
            {
                obstacles[i].SetActive(false);
                a = Random.Range(0, 3);

            }

        }
    }


    void Update()
    {



    }

    
}
