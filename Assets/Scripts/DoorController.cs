using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Impostazioni Porta")]
    public float openAngle = 90f;  
    public float smooth = 2f;       
    public bool isOpen = false;     

    private Quaternion initialRotation;
    private Quaternion openRotation;

    void Start()
    {
        initialRotation = transform.localRotation;
        openRotation = initialRotation * Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        Quaternion targetRotation = isOpen ? openRotation : initialRotation;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}
