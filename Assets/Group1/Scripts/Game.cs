using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class Game : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private List<Booster> _boosters;

    private int _diedEnemies;

    public event UnityAction AllEnemyDied;

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnDied;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnDied;
        }
    }

    private void Update()
    {
        KillEnemy();

        AbsorbBooster();
    }

    private void KillEnemy()
    {
        foreach (var enemy in _enemies)
            CallByDistance(enemy, () => enemy.Die());
    }

    private void AbsorbBooster()
    {
        foreach (var booster in _boosters)
            CallByDistance(booster, () => _playerMover.IncreaseSpeed());
    }

    private void CallByDistance(SceneUnits unit, Action callback)
    {
        if (Vector3.Distance(_player.transform.position, unit.transform.position) < unit.Range)
                callback?.Invoke();
    }

    private void OnDied()
    {
        _diedEnemies++;

        if (_diedEnemies >= _enemies.Count)
            AllEnemyDied?.Invoke();
    }
}
