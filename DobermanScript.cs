using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobermanScript : MonoBehaviour
{
    private Animator anim;
    public float smooth;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
 
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Endgame"))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, other.transform.rotation, Time.deltaTime * smooth);
            StartCoroutine(AnimationCoroutine());
        }
    }
    

    IEnumerator AnimationCoroutine()
    {
        anim.SetTrigger("laysetup");
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("layer");
    }
}


   
    
