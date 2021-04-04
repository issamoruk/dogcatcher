using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DogScript : MonoBehaviour
{
    private Collider[] colliders;
    private Animator anim,anime;
    public AudioSource asource;
    public bool triggered;
    private Vector3 newvector;
    public Movement movement;
    public AudioClip[] barks;
    public float smooth,b;
    private int childs;



    private void Awake()
    {
        anim = GetComponent<Animator>();
        
       
    }
    private void Update()
    {
        if (triggered ==true)
        {
            Vector3 a = transform.position;
            Vector3 b = newvector;
            transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(a, b, 10f), 20f * Time.deltaTime);
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            anim.SetTrigger("Running");
        }
        if (other.CompareTag("LRTRIGGER")) 
        {
            anim.SetTrigger("Running");
        }
        if (other.CompareTag("Cat"))
        {
            movement.dogscore -= 1;
            movement.score -= 100;
            movement.scoretext.text = movement.dogscore.ToString("0") + "x";
            colliders =GameObject.Find("ACTUALSTACKK").GetComponentsInChildren<Collider>();
            foreach (Collider c in colliders)
            {
                c.enabled = false;
            }
            
            transform.rotation = Quaternion.Slerp(transform.rotation, other.transform.rotation, Time.deltaTime * smooth);
            if (!asource.isPlaying)
            {

                int randomClip = Random.Range(0, barks.Length);
                asource.clip = barks[randomClip];
                asource.Play();

                anime = other.gameObject.GetComponent<Animator>();
                anime.SetTrigger("dog");

                newvector = other.transform.position;
                triggered = true;
                StartCoroutine(TriggerOff());
               

                if (movement.dogscore < 0)
                {
                    movement.dogscore = 0;
                }
                if (movement.score < 0)
                {
                    movement.score = 0;
                }
            }
            else
            {
                newvector = other.transform.position;
                triggered = true;
                StartCoroutine(TriggerOff());
     
                if (movement.score < 0)
                {
                    movement.score = 0;
                }
                if (movement.dogscore < 0)
                {
                    movement.dogscore = 0;
                }
            }
            
        }
       
    }
    IEnumerator TriggerOff()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        colliders = GameObject.Find("ACTUALSTACKK").GetComponentsInChildren<Collider>();
        foreach (Collider c in colliders)
        {
            c.enabled = true;
        }
        triggered = false;
        Destroy(this.gameObject);
    }
}