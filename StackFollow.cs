using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    public Vector3 offset;
	Transform parentPickup;
   public FinishScript fscript;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
       
            float value = player.transform.position.z;
            value += 3.5f;
            transform.position = new Vector3(player.position.x, transform.position.y, value);
        
    }

}
