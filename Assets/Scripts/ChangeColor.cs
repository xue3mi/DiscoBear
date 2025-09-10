using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material lineMaterial;
    public float speed = 1.0f;

    void Update()
    {
        float h = Mathf.PingPong(Time.time * speed, 1.0f);
        Color rainbow = Color.HSVToRGB(h, 1, 1);
        lineMaterial.color = rainbow;
    }
}
