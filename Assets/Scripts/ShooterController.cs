using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform spawn_point;
    [SerializeField] private float cooldown;
    [SerializeField] private float bullet_speed;
    [SerializeField] private int damage;

    private float cooldown_timer;

    private void Start() {
        
        RestartTimer();
    }

    private void Update() {
        
        Cooldown_timer();
    }

    private void Shoot()
    {
        var _bullet = Instantiate(bullet, spawn_point.position, Quaternion.identity);
        _bullet.OnStart(bullet_speed, damage);
    }
    private void Cooldown_timer() {
       
        if (cooldown_timer > 0) {
            
            cooldown_timer -= Time.deltaTime;
        }
        else {
            
            Shoot();
            cooldown_timer = cooldown;
        }
    }
    private void RestartTimer() {
       
        cooldown_timer = cooldown;
    }
}
