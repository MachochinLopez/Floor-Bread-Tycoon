using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public float PerSecondBreadGeneration { get; set; }
    public int BreadPerClick { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        BreadPerClick = 1;
        PerSecondBreadGeneration = 0.0f;
    }

    public void IncreasePerSecondGeneration(float amount)
    {
        PerSecondBreadGeneration += amount;
    }
}
