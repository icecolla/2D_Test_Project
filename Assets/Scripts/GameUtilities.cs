using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtilities 
{
    public static void ScaleFlip(float direction, ref Vector3 scale)
    {
        if (direction < 0f)
        {
            scale.x = -1;
        }
        else if (direction > 0f)
        {
            scale.x = 1;
        }
    }

    public static void RotationFlip(float direction, ref Vector3 rotation)
    {
        if (direction < 0f)
        {
            rotation.y = 180;
        }
        else if (direction > 0f)
        {
            rotation.y = 0;
        }
    }
}
