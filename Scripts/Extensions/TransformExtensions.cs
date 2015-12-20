using UnityEngine;
using System.Collections;

public static class TransformExtensions
{
    public static IEnumerator RotateObject(this Transform t, float graus, float tempo)
    {
        float diffGraus = (graus - t.rotation.y);
        float counter = 0;
        while (counter < tempo)
        {
            float movAmount = (Time.deltaTime * diffGraus / tempo);
            t.Rotate(Vector3.up * (movAmount));
            counter += Time.deltaTime;
            yield return null;
        }
    }
}


