using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject[] ob;

    private void OnEnable()
    {
        for (int i = 0; i < ob.Length; i++)
        {
            ob[i].SetActive(Random.Range(0, 7) == 0 ? true : false);
        }
    }

}
