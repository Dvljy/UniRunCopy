using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpawner : MonoBehaviour // �ݷ��� ��� ����
{
    public GameObject platformPrefeb;
    public int count = 3; //���� ���� ��

    public float timeBetSpawnMin = 1.25f; //���� �ּ� �ð�
    public float timeBetSpawnMax = 2.25f; //���� �ִ� �ð�
    private float timeBetSpawn; //�ð�����

    public float yMin = -1.5f; //�ּ� y ��ġ
    public float yMax = 20f; //�ִ� y ��ġ
    private float xPos = 25f; //��ġ x ��

    private GameObject[] platforms; //�迭
    private int currentIndex = 0; //���� ���� ����

    private Vector2 poolPosition = new Vector2(0, -25) ; //���� ���� ���� ��ġ
    private float lastSpawTime; //������ ��ġ ����
    int t;

    void Start()
    {
        //count��ŭ�� ������ ������ ���ο� ���� �迭 ����
        platforms = new GameObject[count];

        //count��ŭ�� ������ ������ ���ο� ���� ����
        for (int i = 0; i < count; i++)
        {
            //������ ������ platform �迭�� �Ҵ�
            //������ poolPosition ��ġ�� ���� ����
            // Quaternion(x,y,z,w)�� ȸ���� ��Ÿ��
            platforms[i] = Instantiate(platformPrefeb, poolPosition, Quaternion.identity);
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

            float yPos = Random.Range(yMin, yMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;

            if (currentIndex >= count)
            {
                currentIndex = 0;
            }

            
        }
   
    }

    
}
