using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    public float Speed;

    public Transform[] waypoints;

    int WayPointIndex = 0;

    public GameObject HP;

    private Bullet bullet;
    void Update()
    {
        if(WayPointIndex < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[WayPointIndex].position, Time.deltaTime * Speed);
            transform.LookAt(waypoints[WayPointIndex].position);

            if(Vector3.Distance(transform.position, waypoints[WayPointIndex].position) <= 5f)
            {
                WayPointIndex++;
            }

            if(HP.GetComponent<HpBar>().curHp <= 0)
            {
                bullet.HitTarget();
            }
        }
    }
}
