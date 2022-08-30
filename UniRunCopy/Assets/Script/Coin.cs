using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject[] coin;

    /*private void OnEnable()
    {
        for (int i = 0; i < coin.Length; i++)
        {
            coin[i].SetActive(Random.Range(0, 3) == 0 ? true : false);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (tag == "Bronze")
            {
                GameManager.score += 1;
            }
            else if (tag == "Silver")
            {
                GameManager.score += 2;
            }
            else if (tag == "Gold")
            {
                GameManager.score += 4;
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
