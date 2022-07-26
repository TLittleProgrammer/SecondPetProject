using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBegin : MonoBehaviour
{
    [SerializeField] private TaskManController _taskMan;

    public void BeginDialog()
    {
        _taskMan.BeginTypeText();
    }
}
