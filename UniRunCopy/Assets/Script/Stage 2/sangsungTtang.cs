using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sangsungTtang : MonoBehaviour
{
    public GameObject platformPrefeb;
    public int count = 3; //발판 생성 수

    public float timeBetSpawnMin = 1.25f; //생성 최소 시간
    public float timeBetSpawnMax = 2.25f; //생성 최대 시간
    private float timeBetSpawn; //시간간격

    private float xPos = 22.5f; //배치 x 값

    private GameObject[] Grounds; //배열
    private int currentIndex = 0; //현재 발판 순서

    private Vector2 poolPosition = new Vector2(0, -25); //생성 발판 숨길 위치
    private float lastSpawTime; //마지막 배치 지점
    int t;

    void Start()
    {
        //count만큼의 공간을 가지는 새로운 발판 배열 생성
        Grounds = new GameObject[count];

        //count만큼의 공간을 가지는 새로운 발판 생성
        for (int i = 0; i < count; i++)
        {
            //생성된 발판을 platform 배열에 할당
            //원본을 poolPosition 위치에 복제 생성
            // Quaternion(x,y,z,w)은 회전을 나타냄
            Grounds[i] = Instantiate(platformPrefeb, poolPosition, Quaternion.identity);
        }

        lastSpawTime = 0f;
        timeBetSpawn = 0f;
    }


    void Update()
    {
        if (GameManager.isDead) return;

        if (Time.time >= lastSpawTime + timeBetSpawn)
        {
            lastSpawTime = Time.time;

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            Grounds[currentIndex].SetActive(false);
            Grounds[currentIndex].SetActive(true);

            Grounds[currentIndex].transform.position = new Vector2(xPos, -5);

            currentIndex++;

            if (currentIndex >= count)
            {
                currentIndex = 0;
            }


        }

    }
}
