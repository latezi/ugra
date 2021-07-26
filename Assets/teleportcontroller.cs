using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class teleportcontroller : MonoBehaviour
{
    public GameObject basecontroller;
    public GameObject teleportaction;

    public InputActionReference telepotrActionReference;
    [Space]
    public UnityEvent onteleportactivate;
    public UnityEvent onteleportcancel;    
        
    void Start()
    {
        telepotrActionReference.action.performed += teleportmodeactivated;
        telepotrActionReference.action.canceled += teleportmodecancel;
    }    

    private void teleportmodecancel(InputAction.CallbackContext obj)
    {
        Invoke("DeactivateTeleporter", .1f);
    }

    void DeactivateTeleporter()
    {
        onteleportcancel.Invoke();
    }
    private void teleportmodeactivated(InputAction.CallbackContext obj)
    {
        onteleportactivate.Invoke();
    }
}
