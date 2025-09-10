using UnityEngine;

public class LightEffect : MonoBehaviour
{

    private Light _discoLight;
    [SerializeField] private float changeInterval = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _discoLight = GetComponent<Light>();
        //time, repeatRate
        InvokeRepeating(nameof(ChangeLightColor), 0f, changeInterval);
    }


    private void ChangeLightColor()
    {
        var randomColor = new Color(Random.value, Random.value, Random.value);
        _discoLight.color = randomColor;
    }
}
