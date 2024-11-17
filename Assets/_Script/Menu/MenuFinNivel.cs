using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinNivel : MonoBehaviour
{
    public void SiguienteNivel()
    {
        var siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > siguienteNivel)
        {
            AdministradorJuego.DisparosPorJuego = 4;
            SceneManager.LoadScene(siguienteNivel);
        }
        else
        {
            CargarMenuPrincipal();
        }

    }

    public void CargarMenuPrincipal()
    {
        AdministradorJuego.DisparosPorJuego = 4;
        SceneManager.LoadScene(0);
    }

    public void ReintentarNivel()
    {
        AdministradorJuego.DisparosPorJuego = 4;
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}