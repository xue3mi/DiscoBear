using UnityEngine;

public class ScaleFromAudioClip : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoundnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;

        //lerp value from minscale to maxscale 
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }


}