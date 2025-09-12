using UnityEngine;

public class scaleFromMicrophone : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoundnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    public ScreenShake screenShake;
    public float shakeTriggerScale = 4.8f;
    private bool hasShaken = false;

    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;


        Vector3 newScale = Vector3.Lerp(minScale, maxScale, loudness);
        transform.localScale = newScale;

        // see if out of bounds
        if (newScale.x >= shakeTriggerScale && !hasShaken)
        {
            screenShake.start = true;
            hasShaken = true;
        }

        //when scale back set it back to false
        if (newScale.x < shakeTriggerScale * 0.8f)
        {
            hasShaken = false;
        }
    }
}
