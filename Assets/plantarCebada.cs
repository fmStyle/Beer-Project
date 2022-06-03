using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class plantarCebada : MonoBehaviour
{
    public GameObject cebada;
    public GameObject lupulo;
    InventarioJugador inventarioJugador;
    // Start is called before the first frame update
    void Start()
    {
        inventarioJugador = GetComponent<InventarioJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        PlantarCebada();
        PlantarLupulo();
    }

    void PlantarCebada() {
        if (Input.GetKeyDown(KeyCode.L) && inventarioJugador.semillasCebada >=1) {
            Instantiate(cebada, gameObject.transform.position, Quaternion.identity);
            inventarioJugador.semillasCebada -=1;
        }
    }
    void PlantarLupulo() {
        if (Input.GetKeyDown(KeyCode.P) && inventarioJugador.semillasLupulo >=1) {
            
            Instantiate(lupulo, gameObject.transform.position, Quaternion.identity);
            inventarioJugador.semillasLupulo -=1;
        }
    }
}
