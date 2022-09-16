using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isAlive = GetComponent<ParticleSystem>().IsAlive();
        if (!isAlive)
        {
            Destroy(gameObject);
        }
    }
}
