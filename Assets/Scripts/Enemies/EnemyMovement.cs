using DG.Tweening;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Tween _move;

    public void Move(Transform target)
    {
        _move = transform.DOMove(target.position, _speed);
    }

    public void UnMove()
    {
        _move.Pause();
    }
}