using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    float times;
    void Start()
    {
        times = Random.Range(1f,3f);
    }

    // Update is called once per frame
    void Update()
    {
        times -= Time.deltaTime;
        if (times <= 0)
        {
            GetComponent<Animator>().Play("trap2");
            times = Random.Range(1f,2f);
        }
    }
}
