using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _deathRange;

    public event UnityAction EnemyDyed;

    private Player _player;

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < _deathRange)
        {
            Die();
        }
    }

    public void Init(Player player)
    {
        _player = player;
    }

    private void Die()
    {
        EnemyDyed?.Invoke();

        Destroy(gameObject);
    }
}
