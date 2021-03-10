using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public GameObject enemy;
    public int curHp = 30;

    public void Damage(int DamageCount)
    {
        curHp -= DamageCount;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(enemy.transform.position);
        GetComponent<Text>().text = curHp.ToString();
    }
}
