using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //  if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("RandomMovement"))
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
