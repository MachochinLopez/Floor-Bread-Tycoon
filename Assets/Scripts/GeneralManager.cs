using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    // REFERENCIA AL UI MANAGER
    private UIManager uiManager;

    // REFERENCIA AL MANAGER DE STATS
    private StatsManager statsManager;

    // VARIABLES DE STATS ACTUALES
    public int ActualBreadAmount { get; set; }
    public int ActualMoneyAmount { get; set; }

    public float cummulativeAux;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar variables
        ActualBreadAmount = 0;
        ActualMoneyAmount = 0;
        cummulativeAux = 0.0f;

        // Inicializar referencias
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        statsManager = this.GetComponent<StatsManager>();

        // Llama cada segundo a la función que agrega panes automáticamente.
        InvokeRepeating("StartAutomaticBreadGeneration", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Al dar clic agrega la cantidad de panes que tenga en sus stats.
    public void IncreaseBreadAmountByClick()
    {
        ActualBreadAmount += statsManager.BreadPerClick;
        uiManager.UpdateBreadCounter(ActualBreadAmount.ToString());
    }

    private void StartAutomaticBreadGeneration()
    {
        // Agrega cada segundo al acumulado la cantidad definida por segundo.
        cummulativeAux += statsManager.PerSecondBreadGeneration;

        // Si el acumulado por segundo es mayor o igual a uno...
        if(cummulativeAux / 1 >= 1)
        {
            // Lo redondea y agrega el valor acumulado en enteros.
            ActualBreadAmount += Mathf.FloorToInt(cummulativeAux);
            // Reinicia el acumulado.
            cummulativeAux = Mathf.Round(cummulativeAux % 1.0f * 100.0f) / 100.0f;
        }

        // Actualiza la UI
        uiManager.UpdateBreadCounter(ActualBreadAmount.ToString());
    }
}
