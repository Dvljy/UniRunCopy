using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuSystem : MonoBehaviour
{
    [SerializeField] string[] but;
    [SerializeField] Transform Panel;
    Button[] btn;
    [SerializeField] Button bu;
    void Awake()
    {
        btn = new Button[but.Length];
    }

    void OnEnable()
    {
        Time.timeScale = 0;
    }
    

    void Start()
    {
        for (int i = 0; i < but.Length; i++)
        {
            btn[i] = Instantiate(bu, Panel);
            btn[i].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, i * -70);
            btn[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = but[i]; ;
            int b = i;
            btn[i].onClick.AddListener(() => Btce(b));
        }
    }

    void Btce(int a)
    {
        switch (a)
        {
            case 0:
                gameObject.SetActive(false);
                break;
            case 1:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case 2:
                Application.Quit();
                break;
        }
    }

 
    void OnDisable()
    {
        Time.timeScale = 1;    
    }
}
