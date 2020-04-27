using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterClick : MonoBehaviour
{
    private BoxCollider2D toasterCollider;
    private GeneralManager generalManager;
    public GameObject bread;

    // Start is called before the first frame update
    void Start()
    {
        toasterCollider = this.GetComponent<BoxCollider2D>();
        generalManager = GameObject.Find("GeneralManager").GetComponent<GeneralManager>();
    }

    // Al hacerle click a la tostadora...
    private void OnMouseDown()
    {
        generalManager.IncreaseBreadAmountByClick();
        Instantiate(bread, transform.GetChild(0).position, Quaternion.identity);
        GetComponent<Animator>().Play("Click");
    }
}
