using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Enemy
{
    public float speed;
    public bool CanAt;
    public float culdawn;
    private Hero hero;
    public int damage;
    void Start()
    {
        target = Hero.singleton.transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
        if (hp <= 0)
        {
            Die();
        }
        if (CanAt)
        {
            StartCoroutine(Attac());
        }
    }
    public override void FollowTarget()
    {
        if(!target)
            return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hero>())
        {
            CanAt = true;
            hero = collision.gameObject.GetComponent<Hero>();
        }
    }
    public IEnumerator Attac()
    {
        yield return new WaitForSeconds(culdawn);
        hero.hp -= damage;
        CanAt = false;
    }
}
