using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private CharacterLogic _characterLogic;

    private void Update()
    {
        _characterLogic = transform.parent.GetComponent<CharacterLogic>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ground ground))
        {
            _characterLogic.SetValueToCanJump(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _characterLogic.SetValueToCanJump(false);
        }
    }
}
