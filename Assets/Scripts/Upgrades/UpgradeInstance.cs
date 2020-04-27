using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeInstance : MonoBehaviour
{
    public Mejora definition;

    public int CurrentAmount { get; set; }
    public int CurrentPrice { get; set; }
    public float CurrentIncrement { get; set; }

    private Text Description;
    private Text Amount;
    private Text Increment;
    private Text Price;
    private Image Icon;

    public UpgradeInstance activatesUpgrade = null;

    public bool isFirstUpgrade = false;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar todos los elementos dle UI de la mejora.
        CurrentAmount = 0;
        CurrentPrice = definition.initialPrice;
        CurrentIncrement = definition.initialIncrement;

        Description = transform.GetChild(0).GetComponent<Text>();
        Amount = transform.GetChild(1).GetComponent<Text>();
        Increment = transform.GetChild(2).GetComponent<Text>();
        Icon = transform.GetChild(3).GetComponent<Image>();
        Price = transform.GetChild(4).GetComponent<Text>();

        Icon.sprite = definition.icon;
        Description.text = definition.description;
        Amount.text = CurrentAmount.ToString();

        switch (definition.costType)
        {
            // Si son panes.
            case 1:
                Price.text = definition.initialPrice.ToString() + " B";
                break;
            // Si es dinero.
            case 2:
                Price.text = definition.initialPrice.ToString() + " $";
                break;
        }

        DefineIncrement(definition.initialIncrement.ToString(), definition.specialIncrement);
        
        if (!isFirstUpgrade)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void UpdateUpgrade()
    {
        Amount.text = CurrentAmount.ToString();
        Price.text = CurrentPrice + " B";
        DefineIncrement(CurrentIncrement.ToString(), definition.specialIncrement);
    }

    private void DefineIncrement(string value, string specialIncrement)
    {
        switch (definition.incrementalAspect)
        {
            // Si son panes por segundo.
            case 1:
                Increment.text = value + " bps";
                break;
            // Si es fama.
            case 2:
                Increment.text = value + " fama";
                break;
            // Si es una mejora especial.
            case 3:
                Increment.text = specialIncrement;
                break;
            default:
                Increment.text = value;
                break;
        }
    }
}
