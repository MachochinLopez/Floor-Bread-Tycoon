using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingsManager : MonoBehaviour
{
    // Referencia al General Manager
    private GeneralManager generalManager;

    // La fama actual de tu empresa. La fama es esencial para las ventas. Es cuántas personas te conocen.
    public int Fame { get; set; }
    public float BreadPrice { get; set; }

    private float cummulativeAux;

    // Start is called before the first frame update
    void Start()
    {
        // Referencia al GeneralManager.
        generalManager = GameObject.Find("GeneralManager").GetComponent<GeneralManager>();

        // Inicializar variables
        Fame = 5;
        BreadPrice = 0.5f;

        // Iniciar la venta de pan.
        InvokeRepeating("SellBread", 1f, 1.0f);
    }

    // Según el nivel de fama, al azar tendrás ventas cada segundo, que no superarán la cantidad de fama que tengas.
    private void SellBread()
    {
        // Vende una cantidad de pan por segundo.
        // Calcula la cantidad de pan que se venderá.
        float calculatedSelling = Random.Range(0, Fame) * BreadPrice;

        // Agrega cada segundo al acumulado la cantidad definida por segundo.
        cummulativeAux += calculatedSelling;

        // Si el acumulado por segundo es mayor o igual a uno...
        if (cummulativeAux / 1 >= 1)
        {
            // Lo redondea y agrega el valor acumulado en enteros.
            int amount = Mathf.FloorToInt(cummulativeAux);

            // Reinicia el acumulado.
            cummulativeAux = Mathf.Round(cummulativeAux % 1.0f * 100.0f) / 100.0f;

            // Suma la cantidad de dinero y actualiza la UI.
            generalManager.IncreaseMoney(amount);
        }
    }
}
