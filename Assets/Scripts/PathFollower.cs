using UnityEngine;
using UnityEngine.SceneManagement;

public class PathFollower : MonoBehaviour
{
    public Transform[] waypoints;
    
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 5.0f;

    public float vibrationSpeed = 5.0f;
    public float vibrationIntensity = 0.1f;

    private int waypointIndex = 0;

    public GameObject steeringWheel;


    private void Update()
    {
        if (waypoints.Length == 0)
            return;

        if (SceneManager.GetActiveScene().name != "Scene_03" &&
            Vector3.Distance(transform.position, waypoints[waypoints.Length - 1].position) < 0.1f)
            SceneManager.LoadScene("Scene_02");

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, Time.deltaTime * movementSpeed);

        Vector3 direction = waypoints[waypointIndex].position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        Vector3 carEuler = transform.eulerAngles;
        Vector3 wheelEuler = steeringWheel.transform.eulerAngles;
        wheelEuler.z = carEuler.y * 100.0f;
        steeringWheel.transform.localEulerAngles = wheelEuler;

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
            waypointIndex++;

        float offsetY = Mathf.PerlinNoise(Time.time * vibrationSpeed, 1.0f) * 2.0f - 1.0f;

        Vector3 vibrationOffset = new Vector3(0, offsetY, 0) * vibrationIntensity;

        transform.localPosition = transform.position + vibrationOffset;
    }
}
