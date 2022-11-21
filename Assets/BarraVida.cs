using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Slider slider;
    private Animator animator;

    protected void Start()
    {
        slider = GetComponent<Slider>();
        animator = GetComponent<Animator>();
    }

    public void CambiarVidaMax (float vidaMax)
    {
        slider.maxValue = vidaMax;
    }

    public void CambiarVidaActual(float vidaActual)
    {
        slider.value = vidaActual;
        animator.SetTrigger("Hit");
    }

    public void StartBarraDeVida(float vidaActual)
    {
        CambiarVidaMax(vidaActual);
        CambiarVidaActual(vidaActual);
    }
}