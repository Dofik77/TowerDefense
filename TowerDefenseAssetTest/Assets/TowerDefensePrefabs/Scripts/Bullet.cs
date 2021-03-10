using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    private float speed = 70f;
    public GameObject deathEffect;

    public Turrell turrel;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();                
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    public void HitTarget()
    {
        Shop.TotalCount++;
        PlayerStats.Money+=5;
        GameObject effects = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effects, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform == target)
        {
            target.GetComponent<MoveToPoint>().HP.GetComponent<HpBar>().Damage(turrel.damage);
            Destroy(gameObject);
        }
    }
}
