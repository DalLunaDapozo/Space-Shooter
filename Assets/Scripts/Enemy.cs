using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    
    private HealthSystem healthSystem;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthSystem = new HealthSystem(health);
        healthSystem.OnDead += HealthSystem_OnDead;
        healthSystem.OnDamaged += OnHitFeedback;
    }

    public void OnStart() {
        animator.Play("_spawn");
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e) {
       
        Destroy(gameObject);
    }

    private void OnHitFeedback(object sender, System.EventArgs e) {

        animator.Play("_on_hit_feedback");
    }

    public void Damage(int damageAmount){
        
        healthSystem.Take_Damage(damageAmount);
    }
}
