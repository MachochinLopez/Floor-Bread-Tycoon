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
    public float ActualIncrementAmount { get; set; }
    public int ActualPerClickAmount { get; set; }

    private float cummulativeAux;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar variables
        ActualBreadAmount = 0;
        ActualMoneyAmount = 0;
        ActualPerClickAmount = 1;
        ActualIncrementAmount = 0.0f;
        cummulativeAux = 0.0f; 

         // Inicializar referencias
         uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        statsManager = this.GetComponent<StatsManager>();

        // Llama cada segundo a la función que agrega panes automáticamente.
        InvokeRepeating("StartAutomaticBreadGeneration", 0.0f, 1.0f);

        // Mostrar el valor inicial de pan por segundo.
        uiManager.UpdateBreadPerSecond(statsManager.PerSecondBreadGeneration.ToString());
    }

    // Al dar clic agrega la cantidad de panes que tenga en sus stats.
    public void IncreaseBreadAmountByClick()
    {
        ActualBreadAmount += ActualPerClickAmount;
        uiManager.UpdateBreadCounter(ActualBreadAmount.ToString());
    }

    public void IncreasePerClickBread(int amount)
    {
        ActualPerClickAmount += amount;
    }

    private void StartAutomaticBreadGeneration()
    {
        // Agrega cada segundo al acumulado la cantidad definida por segundo.
        cummulativeAux += ActualIncrementAmount;

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

    // Al tener ventas se ejecuta este método.
    public void IncreaseMoney(int amount)
    {
        ActualMoneyAmount += amount;
        uiManager.UpdateMoney(ActualMoneyAmount.ToString());
    }

    // Incrementa el valor de generación de pan automático.
    public void IncreaseIncrement(float amount)
    {
        ActualIncrementAmount += amount;
        uiManager.UpdateBreadPerSecond(ActualIncrementAmount.ToString());
    }
}
