using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventSystem_Controller : MonoBehaviour
{
    [Header("Botón seleccionado por defecto")]
    [SerializeField] private Button botonInicial;

    void Start()
    {
        SeleccionarBotonValido();
    }

    void Update()
    {
        GameObject seleccionado = EventSystem.current.currentSelectedGameObject;

        // No hay nada seleccionado
        if (seleccionado == null)
        {
            SeleccionarBotonValido();
            return;
        }

        // Comprobamos si lo seleccionado es un botón
        Button boton = seleccionado.GetComponent<Button>();

        // Si no es un botón o está deshabilitado,
        // buscamos otro botón válido.
        if (boton == null || !boton.interactable)
        {
            SeleccionarBotonValido();
        }
    }

    private void SeleccionarBotonValido()
    {
        // Primero intentamos seleccionar el botón inicial
        if (botonInicial != null && botonInicial.interactable)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(botonInicial.gameObject);
            return;
        }

        // Si el botón inicial está deshabilitado,
        // buscamos cualquier botón interactuable de la escena.
        Button[] botones = FindObjectsByType<Button>(FindObjectsSortMode.None);

        foreach (Button boton in botones)
        {
            if (boton.interactable && boton.gameObject.activeInHierarchy)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(boton.gameObject);
                return;
            }
        }

        // Si absolutamente ningún botón está disponible,
        // dejamos el EventSystem sin selección.
        EventSystem.current.SetSelectedGameObject(null);
    }
}