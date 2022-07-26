using UnityEngine;
using DG.Tweening;
public class BlockEnemy : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    [SerializeField] private Ease _ease;
    [SerializeField] private float _seconds;

    private void Start()
    {
        transform.position = _firstPoint.position;

        transform
            .DOMove(_secondPoint.position, _seconds)
            .SetEase(_ease)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
