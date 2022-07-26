using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManController : MonoBehaviour
{
    [SerializeField] private TaskManScriptableObject _taskManData;
    [SerializeField] private CharacterInfo _characterInfo;
    [SerializeField] private GameObject _uiDialog;
    [SerializeField] private GameObject _pressE;

    private TMP_Text _dialogText;
    private Animator _dialogAnimator;
    private int _textIndex;
    private bool _canContinueType;
    private void Start()
    {
        _canContinueType = true;
        _textIndex = 0;
        GetComponent<SpriteRenderer>().color = _taskManData.ManColor;
        _dialogAnimator = _uiDialog.GetComponent<Animator>();
        _dialogText = _uiDialog.transform.GetChild(0).GetComponent<TMP_Text>();
    }

    public void BeginTypeText()
    {
        if(_textIndex == 0)
        {
            _canContinueType = false;
            StartCoroutine(TypeText(_taskManData.MainDialog[_textIndex++]));
        }
        else if(_textIndex == _taskManData.MainDialog.Length)
        {
            _pressE.SetActive(true);
        }
    }

    public void NextText()
    {
        if(_dialogText.IsActive())
        {
            if (_canContinueType)
            {
                _canContinueType = false;
                if (_textIndex != _taskManData.MainDialog.Length)
                {
                    _dialogText.text = "";
                    StartCoroutine(TypeText(_taskManData.MainDialog[_textIndex++]));
                }
                else
                {
                    _pressE.SetActive(true);
                    _dialogText.text = "";
                    StartCoroutine(TypeText(_taskManData.PostDialog));
                }
            }
        }
    }

    public void CheckQuest()
    {
        if(_textIndex == _taskManData.MainDialog.Length)
        {
            if(_canContinueType)
            {
                if (_characterInfo.Coins != _taskManData.Coins)
                {
                    _dialogText.text = "";
                    StartCoroutine(TypeText(_taskManData.WrongQuest));
                }
                else
                {
                    _dialogText.text = "";
                    StartCoroutine(TypeText("Умничка, ты победил"));
                }
            }
        }
    }

    private IEnumerator TypeText(string text)
    {
        int textSize = text.Length;
        for(int i = 0; i < textSize; i++)
        {
            _dialogText.text += text[i];
            yield return new WaitForSeconds(Random.Range(0.01f, 0.05f));
        }
        _canContinueType = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharacterInfo character))
        {
            _dialogAnimator.SetTrigger("Open");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharacterInfo character))
        {
            _pressE.SetActive(false);
            _dialogAnimator.SetTrigger("Close");
        }
    }
}
