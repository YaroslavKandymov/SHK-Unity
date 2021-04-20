using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Player _player;
    [SerializeField] private List<Enemy> _enemies;

    private int _dyedEnemiesCount;

    public event UnityAction AllEnemyDied;

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.EnemyDyed += OnEnemyDyed;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.EnemyDyed -= OnEnemyDyed;
        }
    }

    private void Start()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Init(_player);
        }
    }

    private void OnEnemyDyed()
    {
        _dyedEnemiesCount++;

        if (_dyedEnemiesCount >= _enemies.Count)
            AllEnemyDied?.Invoke();
    }
}
