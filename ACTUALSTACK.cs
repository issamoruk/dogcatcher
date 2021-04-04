using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTUALSTACK : MonoBehaviour
{
    private Collider[] colliders;
    public Movement movement;
    void Start()
    {
       

    }
    void Update()
    {
        if (movement.collidertrigger == true)
        {
            colliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in colliders)
            {
                c.enabled = false;
            }
            StartCoroutine(ColliderCoroutine());
        }
    }
    IEnumerator ColliderCoroutine()
    {
     
        yield return new WaitForSeconds(1);
        colliders = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider c in colliders)
        {
            c.enabled = true;
        }
    }
}
