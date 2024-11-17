using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bala : MonoBehaviour
{
    public GameObject particulasExplosion;
    public UnityEvent BalaDestruida;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Invoke("Explotar", 3);
            BalaDestruida.Invoke();
        }
        if (collision.gameObject.CompareTag("Obstaculo") || collision.gameObject.CompareTag("Objetivo")) Explotar();
    }

    public void Explotar()
    {
        GameObject particulas = Instantiate(particulasExplosion, transform.position, Quaternion.identity) as GameObject;
        Canon.Bloqueado = false;
        SeguirCamara.objetivo = null;
        Destroy(this.gameObject);
    }
}