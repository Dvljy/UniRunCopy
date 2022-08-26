using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Heart : MonoBehaviour
{
    public static int cur_hp;
    public static int max_hp = 3;
    [SerializeField] GameObject hpImage;
    GameObject[] _hpImages;
    void Start()
    {
        _hpImages = new GameObject[max_hp];

        cur_hp = max_hp;

        for (int i = 0; i < max_hp; i++)
        {
            _hpImages[i] = Instantiate(hpImage, transform);
            _hpImages[i].GetComponent<RectTransform>().anchoredPosition+= new Vector2(60 * i, 0);
            _hpImages[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (cur_hp)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    _hpImages[i].gameObject.SetActive(false);
                }
                break;
            case 1:
                for (int i = 0; i < 2; i++)
                {
                    _hpImages[i].gameObject.SetActive(false);
                }
                break;
            case 2:
                for (int i = 0; i < 1; i++)
                {
                    _hpImages[i].gameObject.SetActive(false);
                }
                break;
        }
    }
}
