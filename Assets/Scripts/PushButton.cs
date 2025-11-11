using System;
using UnityEngine;

public class PushButton : MonoBehaviour, IInteractable
{
    public GameObject dropItem;
    bool dropped;

    void Start()
    {
        dropped = false;
    }
    public void Interact()
    {
        if (dropped == false)
        {
            Instantiate(dropItem, new Vector3(transform.position.x + .25f, 0.5f, transform.position.z + 0.5f), Quaternion.Euler(0f, 0f, 0f));
            dropped = true;
        }
    }
}