using UnityEngine;

public abstract class SceneUnits : MonoBehaviour
{
    [SerializeField] private float _range;

    public float Range => _range;
}
