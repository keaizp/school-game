using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    protected int damage = 0;
    public virtual void Effect(Hero hero1,Hero hero2)
    {

    }
    public virtual int GetDamage()
    {
        return this.damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

class Code : Weapon
{
    Code()
    {
        this.damage = Random.Range(10, 50);
    }
    public override int GetDamage()
    {
        return this.damage;
    }
    public override void Effect(Hero hero1,Hero hero2)
    {
        if (this.damage > 25)
            Console.WriteLine("人品爆发，造成大量伤害！");
        else
            Console.WriteLine("出现大量bug，造成少量伤害");

    }
}
