using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private Color _targetColor;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _game.AllEnemyDied += OnAllEnemyDied;
    }

    private void OnDisable()
    {
        _game.AllEnemyDied -= OnAllEnemyDied;
    }

    private void OnAllEnemyDied()
    {
        Time.timeScale = 0;
        _spriteRenderer.color = _targetColor;
    }
}
