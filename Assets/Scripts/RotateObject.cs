using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float minSpeed = -100f;
    public float maxSpeed = 100f;
    public float changeInterval = 5f;

    private Vector3 rotationSpeed;
    private float timer = 0f;

    void Start()
    {
        SetRandomRotation();
    }

    void Update()
    {
        // self rotate
        transform.Rotate(rotationSpeed * Time.deltaTime);

        //change rotation
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            SetRandomRotation();
            timer = 0f;
        }
    }

    void SetRandomRotation()
    {
        rotationSpeed = new Vector3(
            0f, // will not upside down
            Random.Range(minSpeed, maxSpeed),
            Random.Range(minSpeed, maxSpeed)
        );
    }
}
