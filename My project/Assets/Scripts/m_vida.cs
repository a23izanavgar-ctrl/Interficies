using UnityEngine;

public class m_vida : MonoBehaviour
{
    // Variables privadas
    private int vidaActual = 8;
    private int vidaMaxima = 8;
    private bool estaVivo = true;

    // Métodos Get públicos
    public int GetVidaActual() => vidaActual;
    public bool GetEstaVivo() => estaVivo;

    // 1. FUNCIÓN RECIBIR DAÑO
    public void HacerDaño()
    {
        if (!estaVivo) return;

        vidaActual -= 1;

        if (vidaActual <= 0)
        {
            vidaActual = 0;
            estaVivo = false;
        }
    }

    // 2. FUNCIÓN CURAR
    public void Curar()
    {
        if (!estaVivo) return;

        vidaActual += 1;

        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }

    // 3. FUNCIÓN MATAR
    public void Matar()
    {
        if (!estaVivo) return;

        vidaActual = 0;
        estaVivo = false;
    }

    // 4. FUNCIÓN REVIVIR
    public void Revivir()
    {
        if (estaVivo) return;

        vidaActual = 2;
        estaVivo = true;
    }
}