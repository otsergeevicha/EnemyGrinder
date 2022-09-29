using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(RagdollControl))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private RagdollControl _ragControl;
    [SerializeField] private Animator _animator;

    public int Price {get; private set;} = 1;
    public int Damage {get; private set;} = 1;
    public Transform Target;

    private void Start()
    {
        _ragControl.ChangePhysical(true);
        _enemyMovement.Move(Target);
    }

    public void ChangeStatus()
    {
        _enemyMovement.UnMove();
        _animator.enabled = false;
        _ragControl.ChangePhysical(false);
        Invoke("Off", .5f);
    }

    private void Off()
    {
        gameObject.SetActive(false);
    }
}