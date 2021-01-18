using UnityEngine;

static class Extension
{
    #region LookAt2D
    public static void LookAt2D(this Transform me, Vector2 eye, Vector2 target)
    {
        Vector2 look = target - (Vector2)me.position;

        float angle = Vector2.Angle(eye, look);

        Vector2 right = Vector3.Cross(Vector3.forward, look);

        int dir = 1;

        if (Vector2.Angle(right, eye) < 90)
        {
            dir = -1;
        }

        me.rotation *= Quaternion.AngleAxis(angle * dir, Vector3.forward);
    }

    public static void LookAt2D(this Transform me, Vector2 eye, Transform target)
    {
        me.LookAt2D(eye, target.position);
    }

    public static void LookAt2D(this Transform me, Vector2 eye, GameObject target)
    {
        me.LookAt2D(eye, target.transform.position);
    }
    #endregion
}