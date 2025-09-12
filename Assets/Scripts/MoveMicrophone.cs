using UnityEngine;
using System.Collections;

public class ObjectUpDownCoroutine : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveTime = 3f;
    public float waitTime = 10f;

    private Vector3 startPos;
    private Vector3 targetPos;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * moveDistance;
        StartCoroutine(MoveLoop());
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            // move up
            yield return StartCoroutine(MoveTo(targetPos));
            yield return new WaitForSeconds(waitTime);

            // back
            yield return StartCoroutine(MoveTo(startPos));
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator MoveTo(Vector3 target)
    {
        Vector3 initial = transform.position;
        float elapsed = 0f;

        while (elapsed < moveTime)
        {
            transform.position = Vector3.Lerp(initial, target, elapsed / moveTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}
