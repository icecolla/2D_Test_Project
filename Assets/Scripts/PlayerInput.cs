using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float direction;
    private bool jump;
    private bool fire;

    public float Direction
    {
        get => direction;
    }

    public bool Jump
    {
        get => jump;
    }

    public bool Fire
    {
        get => fire;
    }

    private void Update()
    {
        direction = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);

        jump = Input.GetButtonDown(GlobalStringVars.JUMP);

        fire = Input.GetButtonDown(GlobalStringVars.FIRE_1);
    }
}
