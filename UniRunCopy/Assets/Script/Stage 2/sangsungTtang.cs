using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sangsungTtang : MonoBehaviour
{
    public GameObject platformPrefeb;
    public int count = 3; //���� ���� ��

    public float timeBetSpawnMin = 1.25f; //���� �ּ� �ð�
    public float timeBetSpawnMax = 2.25f; //���� �ִ� �ð�
    private float timeBetSpawn; //�ð�����

    private float xPos = 22.5f; //��ġ x ��

    private GameObject[] Grounds; //�迭
    private int currentIndex = 0; //���� ���� ����

    private Vector2 poolPosition = new Vector2(0, -25); //���� ���� ���� ��ġ
    private float lastSpawTime; //������ ��ġ ����
    int t;

    void Start()
    {
        //count��ŭ�� ������ ������ ���ο� ���� �迭 ����
        Grounds = new GameObject[count];

        //count��ŭ�� ������ ������ ���ο� ���� ����
        for (int i = 0; i < count; i++)
        {
            //������ ������ platform �迭�� �Ҵ�
            //������ poolPosition ��ġ�� ���� ����
            // Quaternion(x,y,z,w)�� ȸ���� ��Ÿ��
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
