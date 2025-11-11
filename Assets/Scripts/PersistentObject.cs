using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    public Transform newParentInScene;

    private void Start()
    {
        GameObject persistentObject = GameObject.FindGameObjectWithTag("Item");
        if (persistentObject != null)
        {
            persistentObject.transform.SetParent(newParentInScene, false);
            persistentObject.transform.localPosition = Vector3.zero;
            persistentObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
