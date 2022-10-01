using System;
using UnityEngine;
using static UnityEngine.Input;

public class Player : MonoBehaviour
{
    [SerializeField] private RepairButton _repairButton;

    private int _money = 0;
    
    public event Action<int> ChangedWallet;
    public event Action<bool> MoneyForRepair;

    private void Update()
    {
        Shooting();
        MoneyForRepair?.Invoke(_money >= _repairButton.Price);
    }

    public void SpendMoney(int spendMoney)
    {
        _money -= spendMoney;
        ChangedWallet?.Invoke(_money);
    }

    private void AcceptMoney(int money)
    {
        _money += money;
        ChangedWallet?.Invoke(_money);
    }

    private void Shooting()
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