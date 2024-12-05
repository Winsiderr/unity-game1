using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public Transform target;
    void Start()
    {
        target = Hero.singleton.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void FollowTarget()
    {

    }
    public virtual void Die()
    {

    }
}
