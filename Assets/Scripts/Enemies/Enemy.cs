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
    [SerializeField] private ParticleSystem _hitEffect;

    public Transform Target;
    
    public int Price {get; private set;} = 1;
    public int Damage {get; private set;} = 1;

    private void Start()
    {
        _ragControl.ChangePhysical(true);
        _enemyMovement.Move(Target);
    }

    public void ChangeStatus()
    {
        _hitEffect.Play();
        _enemyMovement.UnMove();
        _animator.enabled = false;
        _ragControl.ChangePhysical(false);
        Invoke(nameof(Off), .5f);
    }

    private void Off()
    {
        gameObject.SetActive(false);
    }
}