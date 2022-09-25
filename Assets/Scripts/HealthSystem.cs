using System;
using UnityEngine;

public class HealthSystem 
{
    public event EventHandler OnHealthChanged;
    public event EventHandler OnDead;
    public event EventHandler OnDamaged;

    private int health;
    private int healthMax;

    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

    public void OnZeroHealth()
    {
        health = 0;
        if (OnDead != null) OnDead(this, EventArgs.Empty);
    }
    public void Die()
    {
        OnDead?.Invoke(this, EventArgs.Empty);
    }
    public void Take_Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
}
