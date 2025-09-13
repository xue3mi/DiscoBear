using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    public float magnitude = 0.2f;

    [Header("Background Flash")]
    public SpriteRenderer background;
    public Color flashColor = Color.red;
    public float flashSpeed = 10f;

    private Color originalColor;

    [Header("Explosion Effect")]
    public ParticleSystem explosionEffect;
    public float explosionDuration = 3f;

    void Start()
    {
        if (background != null)
        {
            originalColor = background.color;
        }


        if (explosionEffect != null)
            explosionEffect.gameObject.SetActive(false);
    }

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

            // shake position
            float strength = curve.Evaluate(elapsed / duration);
            transform.position = startPosition + Random.insideUnitSphere * magnitude * strength;

            // flash color
            if (background != null)
            {
                float t = Mathf.PingPong(Time.time * flashSpeed, 1f);
                background.color = Color.Lerp(originalColor, flashColor, t);
            }

            yield return null;
        }

        transform.position = startPosition;

        // return color
        if (background != null)
            background.color = originalColor;

        // shaked then explore
        if (explosionEffect != null)
            StartCoroutine(ExplosionRoutine());
    }

    IEnumerator ExplosionRoutine()
    {
        explosionEffect.gameObject.SetActive(true);
        explosionEffect.Play();

        yield return new WaitForSeconds(explosionDuration);

        explosionEffect.Stop();
        explosionEffect.gameObject.SetActive(false);
    }
}
