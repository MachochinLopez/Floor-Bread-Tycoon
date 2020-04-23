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
    public int actualMoneyAmount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar variables
        actualMoneyAmount = 0;
        actualMoneyAmount = 0;

        // Inicializar referencias
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        statsManager = this.GetComponent<StatsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseBreadAmountByClick()
    {
        ActualBreadAmount += statsManager.BreadPerClick;
        uiManager.UpdateBreadCounter(ActualBreadAmount.ToString());
    }
}
