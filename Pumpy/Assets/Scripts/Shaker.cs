using System.Collections;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public IEnumerator Shake(Transform target, float duration, float magnitude, float rotationMagnitude)
    {
        var originalPos = target.localPosition;
        var originalRotation = target.localRotation;

        float timePassed = 0f;

        while (timePassed < duration)
        {
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;
            float rotationOffset = Random.Range(-1f, 1f) * rotationMagnitude;

            target.localPosition = new Vector3(offsetX, offsetY, originalPos.z);
            target.localRotation = Quaternion.Euler(
                new Vector3(
                    originalRotation.x,
                    originalRotation.y,
                    rotationOffset));

            timePassed += Time.deltaTime;

            yield return null;
        }

        target.localPosition = originalPos;
        target.localRotation = originalRotation;
    }
}
