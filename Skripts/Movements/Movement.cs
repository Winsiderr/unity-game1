using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Sprite[] levels = new Sprite[3];
    public int level = 0;
    public Hero target;
    void Start()
    {
        target = Hero.singleton.GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void LevelUp()
    { 

    }
    public virtual void Use()
    {
        
    }
}
