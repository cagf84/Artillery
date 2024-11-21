using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{

    public static AdministradorJuego SingletonAdministradorJuego;
    public static int VelocidadBala = 30;
    public static int DisparosPorJuego = 4;
    public static float VelocidadRotacion = 1;

    public GameObject CanvasGanar;
    public GameObject CanvasPerder;

    [HideInInspector] public List<GameObject> bala;
    public GameObject balaPrefab;
    private Bala bolaScript;
    public GameObject MenuFinJuego;


    public void Awake()
    {
        if (SingletonAdministradorJuego == null)
        {
            SingletonAdministradorJuego = this;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }
    }

    private void Update()
    {
        if (DisparosPorJuego < 0)
        {
            PerderJuego();
        }
    }

    public void GanarJuego()
    {
        CanvasGanar.SetActive(true);
        
    }

    public void PerderJuego()
    {
        CanvasPerder.SetActive(true);        
    }

    void Start()
    {
        Transform[] hijos = GetComponentsInChildren<Transform>();
        foreach (Transform hijo in hijos)
        {
            bala.Add(hijo.gameObject);
        }
    }

    public void EliminarVida()
    {
        var objetoAEliminar = bala[bala.Count - 1];
        Destroy(objetoAEliminar);
        bala.RemoveAt(bala.Count - 1);
        if ((bala.Count-1) <= 0)
        {
            MenuFinJuego.SetActive(true);
            return;
        }
    }

}
