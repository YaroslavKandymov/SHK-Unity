using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        transform.Translate(deltaX, deltaY, 0);
    }
}
