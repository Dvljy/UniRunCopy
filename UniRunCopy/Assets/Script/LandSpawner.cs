using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpawner : MonoBehaviour
{
    public GameObject platformPrefeb;
    public int count = 3; //���� ���� ��

    public float timeSpawnMin = 1.25f; //���� �ּ� �ð�
    public float timeSpawnMax = 2.25f; //���� �ִ� �ð�
    private float timeBetSpawn; //�ð�����

    public float yMin = -3.5f; //�ּ� y ��ġ
    public float xMax = 1.5f; //�ִ� y ��ġ
    private float xPos = 20f; //��ġ x ��

    private GameObject[] platform; //�迭
    private int currentIndex = 0; //���� ���� ����

    private Vector2 poolPosition = new Vector2(0, -25); //���� ���� ���� ��ġ
    private float lastSpawTime; //������ ��ġ ����

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
