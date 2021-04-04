using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetsmallSc : MonoBehaviour
{
    public Transform player, stacks;
    public bool smaller;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(GoSmall(0.3f));
            smaller = true;
        }
    }
    IEnumerator GoSmall(float time)
    {
        Vector3 originalScale = player.transform.localScale;
        Vector3 destinationScale = new Vector3(0.0f, 0.0f, 0.0f);

        float currentTime = 0.0f;

        do
        {
            player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
}
