using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _distance;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Start()
    {
        SetRandomTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            SetRandomTarget();
    }

    private void SetRandomTarget()
    {
        _target = Random.insideUnitCircle * _distance;
    }
}
