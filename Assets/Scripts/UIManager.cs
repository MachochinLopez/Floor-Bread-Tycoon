using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text BreadCounter;
    
    [SerializeField]
    private Text BreadPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        BreadCounter.text = "0";
        BreadPerSecond.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBreadCounter(string amount)
    {
        BreadCounter.text = amount;
    }

    public void UpdateBreadPerSecond(string amount)
    {
        BreadPerSecond.text = amount;
    }
}
