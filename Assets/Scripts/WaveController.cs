using UnityEngine;
using System;
using System.Collections.Generic;


public class WaveController : MonoBehaviour
{


    [SerializeField] private Transform[] enemy_positions;
    [SerializeField] private Enemy enemy_prefab;

    [SerializeField] private List<Enemy> enemies_list;

    [SerializeField] private GameObject text;

    private void Awake()
    {
        InputManager.GetInstance().on_spawn_pressed += SpawnEnemy;
    }

    private void Update()
    {
        enemies_list.RemoveAll(s => s == null);
        if (enemies_list.Count == 0) text.gameObject.SetActive(true);
    }

    private void SpawnEnemy(object sender, EventArgs e)
    {
        text.gameObject.SetActive(false);
        
        for (int i = 0; i < enemy_positions.Length; i++)
        {
            var _enemy = Instantiate(enemy_prefab, enemy_positions[i].transform.position, Quaternion.identity);
            enemies_list.Add(_enemy);
            _enemy.OnStart();
        }
    }
}
