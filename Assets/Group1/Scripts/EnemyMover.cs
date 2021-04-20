using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _distance;
    [SerializeField] private float _speed;

    private Vector3 _targetPoint;

    private void Start()
    {
        _targetPoint = Random.insideUnitCircle * _distance;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);

        if (transform.position == _targetPoint)
            _targetPoint = Random.insideUnitCircle * _distance;
    }
}
