using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Test2 _test;

    private void Start()
    {
        _test.
            ChangeColliderState(true).
            ChangeRigidbodyState(false);
    }
}
