﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public delegate void EventHandler(float damage, GameObject damager);
    public event EventHandler OnTakeDamage;

    public float StartHealth = 3.0f;
    public float DeathDelay = 0.0f;
    public float currentHealth;
    public bool ShouldDestroy = true;

    // Use this for initialization
    void Start()
    {
        currentHealth = StartHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage, GameObject damageUser)
    {
        currentHealth -= damage;
        if(currentHealth <= 0 && ShouldDestroy)
        {
            GameObject.Destroy(gameObject, DeathDelay);
        }
        if(OnTakeDamage != null)
        {
            OnTakeDamage(damage, damageUser);
        }
    }
}
