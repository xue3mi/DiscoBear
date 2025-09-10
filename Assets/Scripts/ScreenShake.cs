using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    public float magnitude = 0.2f;

    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float strength = curve.Evaluate(elapsed / duration);
            transform.position = startPosition + Random.insideUnitSphere * magnitude * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
