using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = PointWalk.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;//?
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);//?

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)//?
        {
            SwitchNextPoint();
        }
    }

    void SwitchNextPoint()
    {
        if(wavepointIndex >= PointWalk.points.Length - 1)
        {
            Destroy(gameObject);
        }

        wavepointIndex++;
        target = PointWalk.points[wavepointIndex];
    }
}
