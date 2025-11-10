using System.Collections;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    [SerializeField]
    GameObject door1;

    [SerializeField]
    GameObject door2;
    public float duration;

    void OnTriggerEnter(Collider other)
    {
        Vector3 door1Pos = door1.transform.position;
        Vector3 door2Pos = door2.transform.position;

        if (other.gameObject.CompareTag("Door"))
        {
            StartCoroutine(MoveToPosition(door1, new Vector3(door1Pos.x, door1Pos.y, door1Pos.z - 1.5f), duration));
            StartCoroutine(MoveToPosition(door2, new Vector3(door2Pos.x, door2Pos.y, door2Pos.z + 1.5f), duration));
        }
    }

    void OnTriggerExit(Collider other)
    {
        Vector3 door1Pos = door1.transform.position;
        Vector3 door2Pos = door2.transform.position;

        if (other.gameObject.CompareTag("Door"))
        {
            StartCoroutine(MoveToPosition(door1, new Vector3(door1Pos.x, door1Pos.y, door1Pos.z + 1.5f), duration));
            StartCoroutine(MoveToPosition(door2, new Vector3(door2Pos.x, door2Pos.y, door2Pos.z - 1.5f), duration));
        }
    }

    IEnumerator MoveToPosition(GameObject obj, Vector3 targetPos, float duration)
    {
        Vector3 startPos = obj.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            obj.transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        obj.transform.position = targetPos; // Ensure it reaches the exact target
    }
}
