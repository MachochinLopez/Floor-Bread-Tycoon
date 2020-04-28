﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DosManos : BuyUpgrade
{
    private float incrementalTweek = 1.3f;
    private float incrementalDetweek = 0.8f;

    new public void Upgrade()
    {
        // Revisa que pueda comprar la mejora.
        if (generalManager.ActualBreadAmount >= upgradeInstance.CurrentPrice)
        {
            // Le resta lo que cuesta del dinero actual.
            generalManager.ActualBreadAmount -= upgradeInstance.CurrentPrice;
            generalManager.IncreasePerClickBread((int) upgradeInstance.CurrentIncrement);

            // Aumenta el número de veces que se ha mejorado y lo despliega.
            upgradeInstance.CurrentAmount++;
            // Aumenta el costo de la mejora
            upgradeInstance.CurrentPrice += Mathf.FloorToInt(upgradeInstance.CurrentPrice * upgradeInstance.definition.incrementalFactor * incrementalTweek);
            // Aumenta el incremento de la mejora
            upgradeInstance.CurrentIncrement += Mathf.FloorToInt(upgradeInstance.CurrentIncrement * upgradeInstance.definition.incrementalFactor * incrementalDetweek);
            // Actualiza el número de la mejora.
            upgradeInstance.UpdateUpgrade();
            // Revisa si puede desbloquear la siguiente mejora.
            CheckIfCanUnlockNextUpgrade();
        }
    }
}
