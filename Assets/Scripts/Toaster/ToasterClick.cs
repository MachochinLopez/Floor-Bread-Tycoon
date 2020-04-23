using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterClick : MonoBehaviour
{
    private BoxCollider2D toasterCollider;
    private GeneralManager generalManager;

    // Start is called before the first frame update
    void Start()
    {
        toasterCollider = this.GetComponent<BoxCollider2D>();
        generalManager = GameObject.Find("GeneralManager").GetComponent<GeneralManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Al hacerle click a la tostadora...
    private void OnMouseDown()
    {
        generalManager.IncreaseBreadAmountByClick();
    }
}
