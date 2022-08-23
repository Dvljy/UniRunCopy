using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject[] ob;

    GameObject[] obstacle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ob.Length; i++)
        {
            obstacle[i] = Instantiate(ob, new Vector3(0, 1, 0), Quaternion.identity);
        }
        
        //GameObject.Instantiate(ob,new Vector3(0,0,0),Quaternion.identity);
    }
}
