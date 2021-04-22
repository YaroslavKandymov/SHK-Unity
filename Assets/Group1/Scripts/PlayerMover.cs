using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        float deltaX = GetAxis("Horizontal");
        float deltaY = GetAxis("Vertical");

        transform.Translate(deltaX, deltaY, 0);
    }

    private float GetAxis(string axis)
    {
        return Input.GetAxis(axis) * _speed * Time.deltaTime;
    }
}
