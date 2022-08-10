using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuSystem : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] Button[] bu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
            if (bu[0].onClick.AddListener(() => ))
            {//
                //Input.GetButtonDown("Continue")
                Panel.SetActive(false);
                Time.timeScale = 1;
            }
            if (bu[1].onClick.AddListener(() => ))
            {//
                //Input.GetButtonDown("ReStart")
                Panel.SetActive(false);
                Time.timeScale = 1;
                SceneManager.LoadScene("Stage 1");
            }
        }
        
    }
}
