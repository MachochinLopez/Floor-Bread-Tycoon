using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public double perSecondBreadGeneration;
    public int BreadPerClick { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        BreadPerClick = 1;
        perSecondBreadGeneration = 0.0d;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
