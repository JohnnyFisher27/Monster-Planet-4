using System;
using UnityEngine;

public class Stats
{
    public int health;
    public int maxHealth;
    public int attack;

    public GameObject me;

    public Action OnDeath;
    
    public Stats(GameObject obj, int hp, int attack)
    {
        me = obj;
        health = hp;
        maxHealth = hp;
        this.attack = attack;
        EventBus.Instance.OnDamage += Hurt;
    }

    public void Hurt(GameObject me, int dmg)
    {
        if(me == this.me)
        {
            health -= dmg;
            if (health <= 0)
            {
                health = 0;
                OnDeath?.Invoke();
            }
        }
    }
}
