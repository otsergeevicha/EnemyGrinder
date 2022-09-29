using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _amountMoney;

    private void OnEnable()
    {
        _player.ChangedWallet += ViewMoney;
    }

    private void OnDisable()
    {
        _player.ChangedWallet -= ViewMoney;
    }

    private void ViewMoney(int money)
    {
        _amountMoney.text = money.ToString();
    }
}
