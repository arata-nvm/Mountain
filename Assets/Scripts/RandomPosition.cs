using UnityEngine;

public class RandomPosition : MonoBehaviour
{

    public static Vector3 GetRandomPos(Vector3 basePos, float distance)
    {
        var randomPosX = Random.Range(-distance, distance);
        var randomPosZ = Random.Range(-distance, distance);
        return basePos + new Vector3(randomPosX, 0, randomPosZ);
    }
}
