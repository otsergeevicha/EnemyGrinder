using System;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private float _maxHealth = 20;
    private float _currentHealth = 20;
    public event Action<float, float> ChangedHealth;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            ApplyDamage(enemy.Damage);
            Debug.Log(_currentHealth);
            ChangedHealth?.Invoke(_currentHealth, _maxHealth);
            enemy.gameObject.SetActive(false);
        }
    }

    public void Repair(int repair)
    {
        _currentHealth += repair;
        _player.SpendMoney(repair);
    }

    private void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
    }
}
