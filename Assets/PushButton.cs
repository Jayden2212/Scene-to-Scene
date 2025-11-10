using System;
using UnityEngine;

public class PushButton : MonoBehaviour, IInteractable
{
    public GameObject clone;
    public void Interact()
    {
        Instantiate(clone, new Vector3(gameObject.transform.position.x + .25f, 1f, gameObject.transform.position.z + 1.5f), Quaternion.Euler(90f, 0f, 0f));
    }
}
