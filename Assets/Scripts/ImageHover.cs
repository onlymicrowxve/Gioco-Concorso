using UnityEngine;
using UnityEngine.EventSystems; // Necessario per rilevare il mouse

public class ImageHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Oggetti da alternare")]
    [Tooltip("Trascina qui lo sfondo NORMALE (quello che si deve vedere quando NON tocchi il bottone).")]
    public GameObject backgroundNormale;

    [Tooltip("Trascina qui lo sfondo SPECIALE (quello che deve APPARIRE quando tocchi il bottone).")]
    public GameObject backgroundAttivo;

    // Quando il mouse ENTRA nel bottone
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Spegni quello normale
        if (backgroundNormale != null) backgroundNormale.SetActive(false);
        
        // Accendi quello speciale
        if (backgroundAttivo != null) backgroundAttivo.SetActive(true);
    }

    // Quando il mouse ESCE dal bottone
    public void OnPointerExit(PointerEventData eventData)
    {
        // Riaccendi quello normale
        if (backgroundNormale != null) backgroundNormale.SetActive(true);

        // Spegni quello speciale
        if (backgroundAttivo != null) backgroundAttivo.SetActive(false);
    }
}