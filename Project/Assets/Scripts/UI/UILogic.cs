using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    private UIData _uiData;

    private void Start()
    {
        _uiData = GetComponent<UIData>();
    }

    public void ChangeCoinCounter()
    {
        _uiData.CharacterInfo.Coins++;
        _uiData.CoinCounter.text = "Монет: " + _uiData.CharacterInfo.Coins.ToString();
    }
}
