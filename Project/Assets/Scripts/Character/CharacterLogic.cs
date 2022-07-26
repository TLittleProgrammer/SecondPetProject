using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class CharacterLogic : MonoBehaviour
{
    [SerializeField] private UnityEvent _dialog;
    [SerializeField] private UnityEvent _dialogPressE;

    private CharacterInfo _characterInfo; 
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private bool _canJump;

    private void Start()
    {
        _canJump        = true;
        _characterInfo  = GetComponent<CharacterInfo>();
        _rigidbody      = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator       = GetComponent<Animator>();
    }

    public void Move(Vector2 direction)
    {
        InputVelocity(direction.x * _characterInfo.Speed, (direction.y == 0 ? _rigidbody.velocity.y :
                                                            (_canJump ? _characterInfo.JumpForce : _rigidbody.velocity.y)));
    }

    public void Stay()
    {
        InputVelocity(0, _rigidbody.velocity.y);
    }

    private void InputVelocity(float valueX, float valueY) 
    {
        if(valueX != 0)
        {
            _spriteRenderer.flipX = valueX < 0;
            SetValueToAnimator("Move", valueX * (valueX > 0 ? 1 : -1));
        }
        else
        {
            SetValueToAnimator("Move", 0f);
        }
        SetValueToAnimator("Jump", valueY);
        _rigidbody.velocity = new Vector2(valueX, valueY);
    }

    public void SetValueToCanJump(bool value)
    {
        _canJump = value;
        if(value)
        {
            _animator.SetBool("StayAtGround", true);
        } 
        else
        {
            _animator.SetBool("StayAtGround", false);
        }
    }

    private void SetValueToAnimator(string name, float value)
    {
        _animator.SetFloat(name, value);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DialogInvoke()
    {
        _dialog.Invoke();
    }

    public void CheckQuest()
    {
        _dialogPressE.Invoke();
    }
}