using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;

    public int health;

    private bool isInvulnerable;

    public event Action OnTakeDamage;

    public event Action OnDie;

    public bool IsDead => health == 0;
    private void Start()
    {
        health = maxHealth;
    }
    public void SetInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;
    }

    public void Dealdamage(int damage)
    {
        if(health ==0) { return; }

        if (isInvulnerable) { return; }

        health = Mathf.Max(health - damage, 0);

        //health -= damage;

        //if(health < 0)
        //{
        //    health = 0;
        //}

        OnTakeDamage?.Invoke();

        if(health == 0)
        {
            OnDie?.Invoke();
        }

        Debug.Log(health);
    }
}
