using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    //[SerializeField] Button[] button;



    // Update is called once per frame
    /*void Update()
    {
        for (int i = 0; i < button.Length; i++)
        {
            int b = i;
            button[i].onClick.AddListener(() => Button(b));
        }

}

void Button(int a)
    {
        switch (a)
        {
            case 0:
                SceneManager.LoadScene("Stage 1");
                break;
            case 1:
                Application.Quit();
                break;
        }
    }*/
    public void StartButton()
    {
        SceneManager.LoadScene("Stage 1");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
