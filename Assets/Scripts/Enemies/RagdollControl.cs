using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _allRigidbodies;

    public void ChangePhysical(bool status)
    {
        for(int i = 0; i < _allRigidbodies.Length; i++)
        {
            _allRigidbodies[i].isKinematic = status;
        }
    }
}