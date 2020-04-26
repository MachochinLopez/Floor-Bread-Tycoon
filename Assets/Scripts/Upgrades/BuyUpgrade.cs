using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgrade : MonoBehaviour
{
    private GeneralManager generalManager;
    private UpgradeInstance upgradeInstance;

    // Start is called before the first frame update
    void Start()
    {
        generalManager = GameObject.Find("GeneralManager").GetComponent<GeneralManager>();
        upgradeInstance = this.GetComponent<UpgradeInstance>();
    }

    // Al dar clic al botón de mejora.
    public void Upgrade()
    {
        // Revisa que pueda comprar la mejora.
        if (generalManager.ActualMoneyAmount >= upgradeInstance.CurrentPrice)
        {
            // Aumenta el número de veces que se ha mejorado y lo despliega.
            upgradeInstance.CurrentAmount++;
            // Aumenta el costo de la mejora
            upgradeInstance.CurrentPrice *= Mathf.FloorToInt(upgradeInstance.definition.incrementalFactor * upgradeInstance.CurrentPrice);
            // Aumenta el incremento de la mejora
            upgradeInstance.CurrentIncrement += upgradeInstance.definition.incrementalFactor * upgradeInstance.CurrentPrice;

            upgradeInstance.UpdateUpgrade();
        }
    }
}
