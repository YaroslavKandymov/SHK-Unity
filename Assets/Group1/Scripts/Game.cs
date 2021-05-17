using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public event UnityAction AllEnemyDied;

    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private List<Enemy> _enemies;

    private int _diedEnemies;

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Dyed += OnDyed;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Dyed -= OnDyed;
        }
    }

    private void OnDyed()
    {
        _diedEnemies++;
        _playerMover.IncreaseSpeed();

        if (_diedEnemies >= _enemies.Count)
            AllEnemyDied?.Invoke();
    }
}
