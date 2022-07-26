using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Tasks/Create Task")]
public class TaskManScriptableObject : ScriptableObject
{
    public Color ManColor;
    public string[] MainDialog;
    public string PostDialog;
    public string WrongQuest;
    public int Coins;
}
