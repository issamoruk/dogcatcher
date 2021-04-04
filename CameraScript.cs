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
        if (movement.speedo != 0 && movement.score == 00)
        {
            transform.position = player.position - offset;
        }  
        else if (gssc.smaller==true)
        {
            transform.position = doberman.position - offset2;        
        }
        else if (movement.speedo == 0)
        {
            transform.position = stack.position - offset;
        }
        else if (movement.speedo != 0 && movement.score ==100)
        {
            transform.position = player.position - offset;
        }
        else if (movement.speedo != 0 && movement.score == 200)
        {
            transform.position = player.position - offset;
        }
        else if (movement.speedo != 0 && movement.score == 300)
        {
            transform.position = player.position - offset;
        }
        else if (movement.speedo != 0 && movement.score == 400)
        {
            transform.position = player.position - offset;
        }
        else if (movement.speedo != 0 && movement.score == 500)
        {
            transform.position = player.position - offset;
        }
        else if (movement.speedo != 0 && movement.score > 500)
        {
            transform.position = player.position - offset;
        }
    }
    IEnumerator CameraCoroutine()
    {
        yield return new WaitForSeconds(3);
        transform.RotateAround(player.transform.position, Vector3.up, 5 * Time.deltaTime);
    }
}