using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public GameObject menuPausa;
    public GameObject menuOpciones;
    public static bool GameIsPause = false;

    public void MostrarMenuPausa()
    {
        menuPausa.SetActive(true);
        if (menuOpciones.activeInHierarchy) menuOpciones.SetActive(false);
        Pause();
    }

    public void OcultarMenuPausa()
    {
        menuPausa.SetActive(false);
        Resume();
    }

    public void RegresarAPantallaPrincipal()
    {
        AdministradorJuego.DisparosPorJuego = 4;
        SceneManager.LoadScene(0);
    }

    public void MostrarMenuOpciones()
    {
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;

    }

    void Pause()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
}