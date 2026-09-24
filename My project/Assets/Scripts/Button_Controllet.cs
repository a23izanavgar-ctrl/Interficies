using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button_Controllet : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private m_vida scriptVida;

    [Header("Imágenes de Vida de 0/8 (Tamaño: 8)")]
    [SerializeField] private Image[] imagenesVida;

    [Header("Botones")]
    [SerializeField] private Button botonDaño;
    [SerializeField] private Button botonCurar;
    [SerializeField] private Button botonMatar;
    [SerializeField] private Button botonRevivir;

    private int ultimaVidaVisualizada = -1;

    

    void Start()
    {
        // El padre de las imágenes es el marco "vida0/8".
        // El marco debe quedar siempre visible.
        if (imagenesVida != null && imagenesVida.Length > 0 && imagenesVida[0] != null)
        {
            imagenesVida[0].transform.parent.gameObject.SetActive(true);
        }

        ActualizarPantalla();
    }

    void Update()
    {
        if (scriptVida != null &&
            scriptVida.GetVidaActual() != ultimaVidaVisualizada)
        {
            ActualizarPantalla();
        }
    }

    void ActualizarPantalla()
    {
        if (scriptVida == null || imagenesVida == null)
            return;

        int vidaActual = scriptVida.GetVidaActual();
        bool vivo = scriptVida.GetEstaVivo();

        ultimaVidaVisualizada = vidaActual;

        // Apagamos todas las imágenes de vida.
        for (int i = 0; i < imagenesVida.Length; i++)
        {
            if (imagenesVida[i] != null)
            {
                imagenesVida[i].gameObject.SetActive(false);
            }
        }

        

        // Si está vivo y tiene vida,
        // activamos la imagen correspondiente.
        if (vivo && vidaActual > 0)
        {
            // 0 = vida8/8
            // 1 = vida7/8
            // 2 = vida6/8
            // ...
            // 7 = vida1/8

            int indice = 8 - vidaActual;

            if (indice >= 0 && indice < imagenesVida.Length)
            {
                imagenesVida[indice].gameObject.SetActive(true);
            }
        }

        // Control de los botones
        if (botonDaño != null)
            botonDaño.interactable = vivo;

        if (botonCurar != null)
            botonCurar.interactable = vivo && vidaActual < 8;

        if (botonMatar != null)
            botonMatar.interactable = vivo;

        if (botonRevivir != null)
            botonRevivir.interactable = !vivo;

    }
}