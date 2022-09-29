using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _capacity;
    [SerializeField] private float _rateSpawn;
    [SerializeField] private GameObject _target;
    
    private SpawnPoint[] _spawnPoints = new SpawnPoint[5];
    private List<Enemy> _enemies = new List<Enemy>();
    private Random _random = new Random();
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        CreatePoolEnemies();
    }

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    private void CreatePoolEnemies()
    {
        for(int i = 0; i < _capacity; i++)
        {
            Enemy enemy = Instantiate(_enemy);
            enemy.Target = _target.transform;
            _enemies.Add(enemy);
            enemy.gameObject.SetActive(false);
        }
    }
    
    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_rateSpawn);
        int randomPoint;
        
        if(_enemies.Count != 0)
        {
            for(int i = 0; i < _enemies.Count; i++)
            {
                randomPoint = _random.Next(_spawnPoints.Length);
                _enemies[i].transform.position = _spawnPoints[randomPoint].transform.position;
                _enemies[i].gameObject.SetActive(true);
                yield return waitForSeconds;
            }
        }
    }
}