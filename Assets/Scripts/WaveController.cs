using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private Transform[] enemy_positions;
    [SerializeField] private Enemy enemy_prefab;

    private void Start()
    {
        SpawnEnemy();
    }
    
    private void SpawnEnemy()
    {
        for (int i = 0; i < enemy_positions.Length; i++)
        {
            var _enemy = Instantiate(enemy_prefab, enemy_positions[i].transform.position, Quaternion.identity);
            _enemy.OnStart();
        }
        
    }
}
