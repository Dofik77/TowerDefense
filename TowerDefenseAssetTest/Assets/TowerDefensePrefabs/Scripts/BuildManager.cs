using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    Turrell turrel;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BM on the scene");
            return;
        }

        instance = this;    
    }

    public GameObject standartTurretPrefab;
    public GameObject anotherTurretPrefab;

    private TurrelBluePrint turretToBuild;

    public bool CanBuild { get { return turrel != null; } }
    public void BuildTurretOn(BasePlatform basa)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enogh money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, basa.GetBuildPosition(), Quaternion.identity);
        basa.turret = turret;

        Debug.Log("Turret ON, money " + PlayerStats.Money);
    }

    public void SelectTurrelToBuild(TurrelBluePrint turrel)
    {
        turretToBuild = turrel;
    }
}
