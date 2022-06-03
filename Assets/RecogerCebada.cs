using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerCebada : MonoBehaviour
{
    //List 

    bool estaCercaDelPozo;

    InventarioJugador inventarioJugador;
    void Start()
    {
        estaCercaDelPozo = false;
        inventarioJugador = GetComponent<InventarioJugador>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (estaCercaDelPozo && Input.GetKeyDown(KeyCode.O)){
    //         if (inventarioJugador.agua < inventarioJugador.maxAgua){
    //             inventarioJugador.agua += 1;
    //         }
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D collision){
    //     if (collision.gameObject.tag == "Pozo"){
    //         estaCercaDelPozo = true;
    //     }
    // }
    // void OnTriggerExit2D(Collider2D collision){
    //     if (collision.gameObject.tag == "Pozo"){
    //         estaCercaDelPozo = false;
    //     }
    // }

    void OnTriggerStay2D(Collider2D collision){
        Debug.Log("Ok");
        if (collision.gameObject.tag == "Cebada" && collision.gameObject.GetComponent<CebadaEstado>().estado == 3 && Input.GetKeyDown(KeyCode.O)){
            if (collision.gameObject.GetComponent<CebadaEstado>().destroyed == false){
                inventarioJugador.cebada += 1;
                inventarioJugador.semillasCebada += 1;
            }
            collision.gameObject.GetComponent<CebadaEstado>().destroyed = true;
        }
        if (collision.gameObject.tag == "Lupulo" && collision.gameObject.GetComponent<LupuloEstado>().estado == 3 && Input.GetKeyDown(KeyCode.O)){
            if (collision.gameObject.GetComponent<LupuloEstado>().destroyed == false){
                inventarioJugador.lupulo += 1;
                inventarioJugador.semillasLupulo += 1;
            }
            collision.gameObject.GetComponent<LupuloEstado>().destroyed = true;
        }
        if (collision.gameObject.tag == "Pozo" && Input.GetKeyDown(KeyCode.O)){
            
            if (inventarioJugador.agua < inventarioJugador.maxAgua){
                inventarioJugador.agua += 1;
                Debug.Log(inventarioJugador.agua);
            }
        }
        if (collision.gameObject.tag == "Fabricar" && Input.GetKeyDown(KeyCode.O)){
            Debug.Log("OK");
            if (inventarioJugador.agua >= 1 && inventarioJugador.cebada >=1 && inventarioJugador.lupulo >=1){
                inventarioJugador.cerveza += 1;
                inventarioJugador.agua -= 1;
                inventarioJugador.cebada -= 1;
                inventarioJugador.lupulo -= 1;
            }
        }
        if (collision.gameObject.tag == "Venta" && Input.GetKeyDown(KeyCode.O)){
            Debug.Log("OK");
            if (inventarioJugador.cerveza >= 1){
                inventarioJugador.cerveza -= 1;
                inventarioJugador.dinero += inventarioJugador.precioCerveza;
            }
        }
        if (collision.gameObject.tag == "Tienda"){
            //
            // Cambiar luego el 20.0f por una variable de precio de las semillas
            if (Input.GetKeyDown(KeyCode.O) && inventarioJugador.dinero >= 20.0f){
                inventarioJugador.semillasCebada += 1;
                inventarioJugador.dinero -= 20.0f;
            }
            if (Input.GetKeyDown(KeyCode.I) && inventarioJugador.dinero >= 20.0f){
                inventarioJugador.semillasLupulo += 1;
                inventarioJugador.dinero -= 20.0f;
            }
        }

    }
}
