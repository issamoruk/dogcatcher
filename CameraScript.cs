using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player,stack,doberman;
    public Vector3 offset,offset2;
    public GetsmallSc gssc;
    public Movement movement;
    private Camera maincamera;
    public float FOV;

    private void Start()
    {
        maincamera = GetComponent < Camera>();
    }
    public void CameraWiev(float zoom)
    {
        FOV = zoom;
    }
    void LateUpdate()
    {
        maincamera.fieldOfView = FOV;
        if (movement.speedo != 0)
        {
            transform.position = player.position - offset;
        }  
        else if (gssc.smaller==true)
        {
            transform.position = doberman.position - offset2;        
        }
      
     
    }
    IEnumerator CameraCoroutine()
    {
        yield return new WaitForSeconds(3);
        transform.RotateAround(player.transform.position, Vector3.up, 5 * Time.deltaTime);
    }
}