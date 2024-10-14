using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject BalaPrefab;
    private GameObject puntaCanon;
    private float rotation;
    private int DisparosBala;
    private int DisparosCanon = 0;
    private void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        DisparosBala = AdministradorJuego.DisparosPorJuego;
    }

    private void Update()
    {        
        rotation += Input.GetAxis("Horizontal") * AdministradorJuego.VelocidadRotacion;
        if (rotation <= 90 && rotation >= 0)
        {
            transform.eulerAngles = new Vector3(rotation, 90, 0.0f);
        }

        if (rotation > 90) rotation = 90;
        if (rotation < 0) rotation = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DisparosCanon != DisparosBala)
            { 
                GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
                Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                Vector3 direccionDisparo = transform.rotation.eulerAngles;
                direccionDisparo.y = 90 - direccionDisparo.x;
                tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala;
                DisparosCanon++;
            }
            else
            {
                Debug.LogWarning("No hay mas balas");
            }
            
        }
    }
}