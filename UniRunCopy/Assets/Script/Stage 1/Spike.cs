using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;

    private void OnEnable()
    {
        
        for (int i = 0; i < obstacles.Length; i++)
        {
          
            obstacles[i].SetActive(Random.Range(0, 3) == 0 ? true : false);
        }
        
    }
}
