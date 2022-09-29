using System;
using UnityEngine;
using static UnityEngine.Input;

public class Player : MonoBehaviour
{
    [SerializeField] private RepairButton _repairButton;

    private int _walletMoney = 0;
    public event Action<int> ChangedWallet;
    public event Action<bool> MoneyForRepair;

    private void Update()
    {
        CheckCollision();

        if(_walletMoney >= _repairButton.Price)
            MoneyForRepair?.Invoke(true);
        else
            MoneyForRepair?.Invoke(false);
    }

    public void SpendMoney(int spendMoney)
    {
        _walletMoney -= spendMoney;
        ChangedWallet?.Invoke(_walletMoney);
    }

    private void AcceptMoney(int money)
    {
        _walletMoney += money;
        ChangedWallet?.Invoke(_walletMoney);
    }

    private void CheckCollision()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    AcceptMoney(enemy.Price);
                    enemy.ChangeStatus();
                }
            }
        }
    }
}