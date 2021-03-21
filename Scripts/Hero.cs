using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private new string name;
    private int lifeValue = 100;
    private int speed = 0;
    private int strength = 0;
    private int intelligence = 0;
    private int agility = 0;
    private int fist = 0;

    public Hero(string name)
    {
        this.name = name;
        this.fist = 25 + this.strength;
    }

    public int Current()
    {
        Console.WriteLine(this.name + "µ±Ç°ÑªÁ¿£º"+this.lifeValue);
        return lifeValue;
    }

    public void UseFist(Hero hero)
    {
        hero.Hurted(this.fist);
    }

    public void UseWeapon(Weapon weapon,Hero hero)
    {
        int damage = weapon.GetDamage();
        weapon.Effect(this, hero);
        hero.Hurted(this.strength + damage);
    }
    public void Hurted(int damage)
    {
        this.lifeValue = this.lifeValue - damage;
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