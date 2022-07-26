using UnityEngine;
using UnityEngine.Events;

public class CharacterCollider : MonoBehaviour
{
    [SerializeField] private UnityEvent _getCoin;
    private CharacterLogic _characterLogic;
    static int x = 0;
    private void Start()
    {
        _characterLogic = GetComponent<CharacterLogic>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _characterLogic.ReloadScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
            _getCoin.Invoke();
        }
    }
}
