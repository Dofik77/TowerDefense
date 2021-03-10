using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpBase : MonoBehaviour
{
    public int Hp = 100;

    public Text HPtext;
    void Update()
    {
        HPtext.text = "Health: " + Hp.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Hp -= 1;
            Destroy(other.gameObject);
            if (Hp <= 0)
            {
                SceneManager.LoadScene("MainScene");
            }
        }    
    }
}
