using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractVendingMachineObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene("Scene_03");
        DontDestroyOnLoad(gameObject);
    }
}
