using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _radius;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Start()
    {
        AssignRandomTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            AssignRandomTarget();
    }

    private void AssignRandomTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
