using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autokill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
