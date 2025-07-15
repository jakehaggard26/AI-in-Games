using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesTarget : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * speed;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
