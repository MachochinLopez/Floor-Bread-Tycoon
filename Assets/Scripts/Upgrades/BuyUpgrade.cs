using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuyUpgrade : MonoBehaviour
{
    protected GeneralManager generalManager;
    protected UpgradeInstance upgradeInstance;

    // Start is called before the first frame update
    void Start()
    {
        generalManager = GameObject.Find("GeneralManager").GetComponent<GeneralManager>();
        upgradeInstance = gameObject.GetComponent<UpgradeInstance>();
    }


    // Revisa si ya se puede comprar la mejora.
    void Update()
    {   
        upgradeInstance.GetComponent<Button>().interactable = (generalManager.ActualBreadAmount >= upgradeInstance.CurrentPrice);
    }


    // Al dar clic al botón de mejora.
    public void Upgrade()
    {
        // Revisa que pueda comprar la mejora.
        if (generalManager.ActualBreadAmount >= upgradeInstance.CurrentPrice)
        {
            // Le resta lo que cuesta del dinero actual.
            generalManager.ActualBreadAmount -= upgradeInstance.CurrentPrice;
            generalManager.IncreaseIncrement(upgradeInstance.CurrentIncrement);

            // Aumenta el número de veces que se ha mejorado y lo despliega.
            upgradeInstance.CurrentAmount++;
            // Aumenta el costo de la mejora
            upgradeInstance.CurrentPrice += Mathf.FloorToInt(upgradeInstance.definition.incrementalFactor * upgradeInstance.CurrentPrice);
            // Aumenta el incremento de la mejora
            upgradeInstance.CurrentIncrement += Mathf.Floor(upgradeInstance.CurrentIncrement * upgradeInstance.definition.incrementalFactor * 100) / 100;
            // Actualiza el número de la mejora.
            upgradeInstance.UpdateUpgrade();
            // Revisa si puede desbloquear la siguiente mejora.
            CheckIfCanUnlockNextUpgrade();
        }
    }

    // Revisa si puede desbloquear la siguiente mejora.
    protected void CheckIfCanUnlockNextUpgrade()
    {
        // Al llegar al nivel 5
        if (upgradeInstance.CurrentAmount == 5)
        {
            // Desbloquea la siguiente mejora.
            UnlockUpgrade();
        }
    }

    // Desbloquear la siguiente mejora.
    protected void UnlockUpgrade()
    {
        if(upgradeInstance.activatesUpgrade != null)
        {
            upgradeInstance.activatesUpgrade.gameObject.SetActive(true);
        }
    }
}
