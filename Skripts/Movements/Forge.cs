using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : Movement
{
    void Start()
    {
        target = Hero.singleton.GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Use()
    {
        print("zzzzz");
        target.wood += 1;
    }
    public override void LevelUp()
    {
        level ++;
        gameObject.GetComponent<SpriteRenderer>().sprite = levels[level];
    }
}
