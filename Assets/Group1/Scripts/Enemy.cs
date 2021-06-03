using UnityEngine.Events;

public class Enemy : SceneUnits
{
    public event UnityAction Died;

    public void Die()
    {
        Died?.Invoke();

        Destroy(gameObject);
    }
}
