using UnityEngine;

public class PickUpandDrop : MonoBehaviour
{
    [Header("Impostazioni")]
    public float pickupRange = 3f;
    
    [Header("Riferimenti")]
    public GameObject hand;
    public Transform playerCamera;

    void Update()
    {
        HandleInteraction();
        HandleDrop();
    }

    void HandleInteraction()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;

        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, pickupRange))
        {
            if (hit.transform.CompareTag("Door"))
            {
                DoorController door = hit.transform.GetComponent<DoorController>();
                if (door == null) door = hit.transform.GetComponentInParent<DoorController>();
                if (door != null) door.ToggleDoor();
            }
            else if (hand.transform.childCount < 1)
            {
                if (hit.transform.CompareTag("PickUp") || hit.transform.CompareTag("ArmaDaTerra"))
                {
                    PickUpObject(hit.transform);
                }
            }
            else if (hand.transform.childCount > 0 && hit.transform.CompareTag("Ammo"))
            {
                ColorWeapon weapon = hand.GetComponentInChildren<ColorWeapon>();
                
                if (weapon != null)
                {
                    weapon.AddAmmo(10);
                    Destroy(hit.transform.gameObject);
                }
            }
            else if (hand.transform.childCount > 0 && hit.transform.CompareTag("Ammo"))
            {
                ColorWeapon weapon = hand.GetComponentInChildren<ColorWeapon>();
    
                if (weapon != null)
                    {
                        weapon.AddAmmo(10);
                        Destroy(hit.transform.gameObject); 
                    }
            }
        }
    }

    void PickUpObject(Transform item)
    {
        // Fisica
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        // Posizionamento
        item.position = hand.transform.position;
        item.rotation = hand.transform.rotation;
        item.parent = hand.transform;

        // Abilita la logica dell'arma
        ColorWeapon weaponScript = item.GetComponent<ColorWeapon>();
        if (weaponScript != null)
        {
            weaponScript.isHeld = true;
            weaponScript.fpsCamera = playerCamera.GetComponent<Camera>();
        }
    }

    void HandleDrop()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (hand.transform.childCount > 0)
            {
                Transform item = hand.transform.GetChild(0);
                ColorWeapon weaponScript = item.GetComponent<ColorWeapon>();
                if (weaponScript != null)
                {
                    weaponScript.isHeld = false;
                }

                item.parent = null;

                Rigidbody rb = item.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.linearVelocity = playerCamera.forward * 10f;
                }
            }
        }
    }
}