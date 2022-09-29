using System;
using UnityEngine;
using UnityEngine.UI;

public class RepairButton : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Button _button;
    
    public int Price {get;private set;} = 5;
    
    private void Start()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _player.MoneyForRepair += OnButton;
    }

    private void OnDisable()
    {
        _player.MoneyForRepair -= OnButton;
    }

    private void OnButton(bool status)
    {
        _button.interactable = status;
    }
}
