using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoHauUsedFullMethods
{
    public static Quaternion LookAt(Vector3 Position,Vector3 gameObjectPosition,float offsetDeg)
    {
        Vector2 direction = new Vector2(Position.x - gameObjectPosition.x, Position.y - gameObjectPosition.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offsetDeg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public static Vector3 RamdomPosition(float a, float b,float zPosition)
    {
        Vector3 position;
        position.x = Random.Range(a, b);
        position.y = Random.Range(a, b);
        position.z = zPosition;
        return position;
    }
 

}
