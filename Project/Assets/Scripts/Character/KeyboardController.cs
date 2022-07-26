using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    private CharacterLogic _characterLogic;

    private void Start()
    {
        _characterLogic = GetComponent<CharacterLogic>();
    }

    private void Update()
    {
        Vector2 direction = Vector2.zero;

        if(Input.GetKey(KeyCode.A))
        {
            direction.x -= 1f;
        }
        if(Input.GetKey(KeyCode.D))
        {
            direction.x += 1f;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            direction.y = 1f;
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            _characterLogic.DialogInvoke();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            _characterLogic.CheckQuest();
        }

        if(direction != Vector2.zero)
        {
            _characterLogic.Move(direction);
        }
        else
        {
            _characterLogic.Stay();
        }
    }
}
