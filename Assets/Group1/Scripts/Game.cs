using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public event UnityAction AllEnemyDied;

    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Player _player;
    [SerializeField] private List<Enemy> _enemies;

    private int _diedEnemies;

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

    private void OnEnemyDyed()
    {
        _diedEnemies++;

        if (_diedEnemies >= _enemies.Count)
            AllEnemyDied?.Invoke();
    }
}
