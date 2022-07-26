using UnityEngine;
using DG.Tweening;

public class SawEnemy : MonoBehaviour
{
    private void Start()
    {
        int random = Random.RandomRange(-1, 1);
        transform
            .DORotate(new Vector3(0, 0, 360f * (random == 0 ? 1 : random)), 2f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
}
