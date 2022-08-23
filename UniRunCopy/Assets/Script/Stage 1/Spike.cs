using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;




    int a;

    private void OnEnable()
    {
        
        for (int i = 0; i < obstacles.Length; i++)
        {
            /*if (Random.Range(0, 3) > 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }*/
            obstacles[i].SetActive(Random.Range(0, 3) == 0 ? true : false);
        }
        
    }

    void Start()
    {
        a = Random.Range(0, 3);
        
        
    }


    void Update()
    {
        
    }


}
