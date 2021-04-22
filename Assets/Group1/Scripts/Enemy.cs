using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction EnemyDyed;

    [SerializeField] private float _deathRange;
    [SerializeField] private Player _player;

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < _deathRange)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyDyed?.Invoke();

        Destroy(gameObject);
    }
}
