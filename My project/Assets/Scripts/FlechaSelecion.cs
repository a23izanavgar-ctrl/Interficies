using UnityEngine;
using UnityEngine.EventSystems;

public class FlechaSelecion : MonoBehaviour
{
    [Header("Flecha que seguirá al botón")]
    [SerializeField] private RectTransform flecha;

    [Header("Distancia respecto al botón")]
    [SerializeField] private float distancia = 30f;

    void Update()
    {
        GameObject botonSeleccionado = EventSystem.current.currentSelectedGameObject;

        if (botonSeleccionado == null)
        {
            flecha.gameObject.SetActive(false);
            return;
        }

        RectTransform boton = botonSeleccionado.GetComponent<RectTransform>();

        if (boton == null)
            return;

        flecha.gameObject.SetActive(true);

        // Colocamos la flecha a la derecha del botón
        flecha.position = boton.position + Vector3.right * distancia;
    }
}