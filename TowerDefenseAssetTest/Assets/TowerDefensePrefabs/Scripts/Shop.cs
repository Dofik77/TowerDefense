using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurrelBluePrint standartTurrel;
    public TurrelBluePrint anotherTurrel;

    public Text moneyText;
    public Text totalCount;

    public static int TotalCount;


    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void BuyStandartTurrel()
    {
        Debug.Log("Turret buy");
        buildManager.SelectTurrelToBuild(standartTurrel);
    }

    public void BuyAcceleratedTurrel()
    {
        Debug.Log("Turret X2 Buy");
        buildManager.SelectTurrelToBuild(anotherTurrel);
    }

    void Update()
    {
        moneyText.text = "Money: " + PlayerStats.Money.ToString();
        totalCount.text = "Score: " + TotalCount.ToString();
    }
}
