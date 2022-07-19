using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpawner : MonoBehaviour
{
    public GameObject platformPrefeb;
    public int count = 3; //발판 생성 수

    public float timeSpawnMin = 1.25f; //생성 최소 시간
    public float timeSpawnMax = 2.25f; //생성 최대 시간
    private float timeBetSpawn; //시간간격

    public float yMin = -3.5f; //최소 y 위치
    public float xMax = 1.5f; //최대 y 위치
    private float xPos = 20f; //배치 x 값

    private GameObject[] platform; //배열
    private int currentIndex = 0; //현재 발판 순서

    private Vector2 poolPosition = new Vector2(0, -25); //생성 발판 숨길 위치
    private float lastSpawTime; //마지막 배치 지점

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
