using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            mr.material.color = Color.green;
        }
    }
}
