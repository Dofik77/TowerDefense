using UnityEngine;
using System.Collections;

public class AlternativeWaveSpawn : MonoBehaviour
{
    public int WaveSize;

    public GameObject EnemyPrefab;

    public float EnemyInterval;

    public Transform spawnPoint;

    public float startTime;

    public string gateTag;

    public Transform[] WayPoints;

    public GameObject HP;

    public int EnemyCount = 0;

    public GameObject canvas;

    void Start()
    {
        InvokeRepeating("SpawnEnemy",startTime,EnemyInterval);
    }

    void Update()
    {
        if(EnemyCount == WaveSize)
        {
            CancelInvoke("SpawnEnemy");
        }
    }
   
    void SpawnEnemy()
    {
        EnemyCount++;
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        enemy.GetComponent<MoveToPoint>().waypoints = WayPoints;
        GameObject hp = GameObject.Instantiate(HP, Vector3.zero, Quaternion.identity) as GameObject;
        hp.transform.SetParent(canvas.transform);
        hp.GetComponent<HpBar>().enemy = enemy;
        enemy.GetComponent<MoveToPoint>().HP = hp;
    }

}
