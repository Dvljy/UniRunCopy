using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource audio;
    //public AudioClip Main;

    public bool isGameOver = false;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameoverUI;
    private int score = 0;
    public static bool isDead = false;


    void Awake()
    {
        audio = GetComponent<AudioSource>();
        //audio.clip = Main;
        audio.Play();
        if (instance == null)
        {
            instance = this;
        } //instance �� ��������� �ڱ� �ڽ��� �Ҵ�
        else
        {
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }




    }

    void Update()
    {
       
        if ( Input.GetMouseButton(1)||Input.GetKeyDown(KeyCode.Space)&&isDead)
        {
            SceneManager.LoadScene("Stage 1");
            isDead = false;
        }
        if (score >= 20)
        {
            SceneManager.LoadScene("Stage 2");
        }
        if (isDead)
        {
            OnPlayerDead();
            Time.timeScale = 1;
        }
            
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    public void OnPlayerDead()
    {
        if (!isGameOver)
        {
            gameoverUI.SetActive(true);
        }
        Time.timeScale = 0;

    }
}
