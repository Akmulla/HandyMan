using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathfFunc 
{
    public static void RotateToPoint(Vector3 point, Transform transform)
    {
        point.z = 0;
        float angle = Vector2.Angle(Vector2.right, point - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < point.y ? angle : -angle);
    }
}
