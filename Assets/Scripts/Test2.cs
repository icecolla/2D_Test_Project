using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private BoxCollider _collider;

    public Test2 ChangeRigidbodyState(bool state)
    {
        _rb.isKinematic = state;
        return this;
    }

    public  Test2 ChangeColliderState(bool state)
    {
        _collider.enabled = state;
        return this;
    }
}
