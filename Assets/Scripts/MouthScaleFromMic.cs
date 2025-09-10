using UnityEngine;

public class MouthScaleFromMic : MonoBehaviour
{
    public AudioLoundnessDetection detector;
    public float loudnessSensibility = 50;
    public float threshold = 0.05f;

    public Vector3 baseScale = new Vector3(1, 1, 1);
    public Vector3 openScale = new Vector3(1, 2, 1);

    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;

        transform.localScale = Vector3.Lerp(baseScale, openScale, loudness);
    }
}
