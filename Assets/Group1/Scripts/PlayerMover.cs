using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxBoostedSpeedTime;

    private bool _speedIncreased;

    private void Update()
    {
        float deltaX = GetAxis("Horizontal");
        float deltaY = GetAxis("Vertical");

        transform.Translate(deltaX, deltaY, 0);
    }

    public void IncreaseSpeed()
    {
        if(_speedIncreased)
            return;

        _speedIncreased = true;
        _speed += _speed;

        StartCoroutine(ResetSpeed());
    }

    private float GetAxis(string axis)
    {
        return Input.GetAxis(axis) * _speed * Time.deltaTime;
    }

    private IEnumerator ResetSpeed()
    {
        var boostedSpeedTime = _maxBoostedSpeedTime;

        while (_speedIncreased)
        {
            boostedSpeedTime -= Time.deltaTime;

            if (boostedSpeedTime <= 0)
            {
                boostedSpeedTime = _maxBoostedSpeedTime;
                _speed -= _speed;
                _speedIncreased = false;
            }

            yield return null;
        }
    }
}
