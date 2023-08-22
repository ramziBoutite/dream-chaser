using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable_health_txt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health_text health_Text_ = GetComponent<health_text>();
        health_Text_.enabled = true;
    }
}
