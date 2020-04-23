using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public float PerSecondBreadGeneration { get; set; }
    public int BreadPerClick { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        BreadPerClick = 1;
        PerSecondBreadGeneration = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
