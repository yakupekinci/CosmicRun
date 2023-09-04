using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            GetComponent<Animator>().Play("trap");
            time = Random.Range(0f, 2f);
        }
    }
}
