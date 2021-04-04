using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    public float speed,speedo;
    public Movement movement;
    public AudioSource asource, music;
    public AudioClip drum, onetwo, threefive;
    public GameObject doggydog,finito,score100t,score200t,score300t,score400t,score500t,g1,g2,g3,g4,g5,confettil1,confettil2,confettir1,confettir2,dobermango,sbars,failedpanel,ggpanel,o1,o2,o3,o4,o5,o6;
    public Transform doggorb,scorebar;
    public Animator anim;
    public bool yallah,score100,score200,score300,score400,score500;
    public ParticleSystem p100, p200, p300, p400, p500,Llaser,Rlaser;
    public Text goldcollectedtext;
    private GameObject a;

    public void Start()
    {
        a = GameObject.Find("Stack");
    }
    public void Update()
    {
        if (score100==true)
        {
            float step = speedo * Time.deltaTime;
            scorebar.position = Vector3.MoveTowards(scorebar.position, score100t.transform.position, step);
        }
        else if (score200 == true)
        {
            float step = speedo * Time.deltaTime; 
            scorebar.position = Vector3.MoveTowards(scorebar.position, score200t.transform.position, step);
        }
        else if (score300 == true)
        {
            float step = speedo * Time.deltaTime; 
            scorebar.position = Vector3.MoveTowards(scorebar.position, score300t.transform.position, step);
        }
        else if (score400 == true)
        {
            float step = speedo * Time.deltaTime; 
            scorebar.position = Vector3.MoveTowards(scorebar.position, score400t.transform.position, step);
        }
        else if (score500 == true)
        {
            
            float step = speedo * Time.deltaTime; 
            scorebar.position = Vector3.MoveTowards(scorebar.position, score500t.transform.position, step);

        }
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            if ( movement.dogscore == 0)
            {
                movement.moveSpeed = 0;

                failedpanel.SetActive(true);
                goldcollectedtext.text = "Collected Coin : " + movement.goldScore.ToString();
            }
            else if ( movement.dogscore == 1)
            {
                o1.SetActive(true);
                StartCoroutine(Dogscore1());
            }
            else if ( movement.dogscore == 2)
            {
                StartCoroutine(Dogscore2());
                StartCoroutine(NumberCoroutine());
            }
            else if (movement.dogscore == 3)
            {
                StartCoroutine(Dogscore3());
                StartCoroutine(NumberCoroutine2());
            }
            else if ( movement.dogscore == 4)
            {
                StartCoroutine(Dogscore4());
                StartCoroutine(NumberCoroutine3());
            }
            else if (movement.dogscore == 5)
            {
                StartCoroutine(Dogscore5());
                StartCoroutine(NumberCoroutine4());
            }
            else if (movement.dogscore == 6)
            {
                StartCoroutine(Dogscore5());
                StartCoroutine(NumberCoroutine5());
            }
        }
    }
    IEnumerator NumberCoroutine()
    {
        o1.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o2.SetActive(true);
    }
    IEnumerator NumberCoroutine2()
    {
        o1.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o2.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o3.SetActive(true);
    }
    IEnumerator NumberCoroutine3()
    {
        o1.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o2.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o3.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o4.SetActive(true);
    }
    IEnumerator NumberCoroutine4()
    {
        o1.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o2.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o3.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o4.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o5.SetActive(true);
    }
    IEnumerator NumberCoroutine5()
    {
        o1.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o2.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o3.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o4.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o5.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        o6.SetActive(true);
    }
    IEnumerator Dogscore1()
    {
        yield return new WaitForSeconds(4.5f);
        a.GetComponent<StackFollow>().enabled = false;
        a.GetComponent<Stack2>().enabled = true;

        StartCoroutine(GGPanel());
        movement.speedo = 0;
        sbars.SetActive(false);
        dobermango.SetActive(true);

        StartCoroutine(FinishParticle());

        GoldCheck();

        StartCoroutine(ONETWOCOROUTINE());
        StartCoroutine(Score100(3));
        StartCoroutine(Score100Coroutine());
        yallah = true;
    }
    IEnumerator Dogscore2()
    {
        yield return new WaitForSeconds(4.5f);
        a.GetComponent<StackFollow>().enabled = false;
        a.GetComponent<Stack2>().enabled = true;
        StartCoroutine(GGPanel());
        movement.speedo = 0;
        sbars.SetActive(false);
        dobermango.SetActive(true);
        StartCoroutine(FinishParticle());
        GoldCheck();


        StartCoroutine(ONETWOCOROUTINE());
        StartCoroutine(Score200(3));
        StartCoroutine(Score200Coroutine());
        yallah = true;
    }
    IEnumerator Dogscore3()
    {
        yield return new WaitForSeconds(4.5f);
        a.GetComponent<StackFollow>().enabled = false;
        a.GetComponent<Stack2>().enabled = true;
        StartCoroutine(GGPanel());
        movement.speedo = 0;
        sbars.SetActive(false);
        dobermango.SetActive(true);
        StartCoroutine(FinishParticle());

        GoldCheck();
        StartCoroutine(THREEFIVECOROUTINE());

        StartCoroutine(Score300(3));
        StartCoroutine(Score300Coroutine());
        yallah = true;
    }
    IEnumerator Dogscore4()
    {
        yield return new WaitForSeconds(4.5f);
        a.GetComponent<StackFollow>().enabled = false;
        a.GetComponent<Stack2>().enabled = true;
        StartCoroutine(GGPanel());
        movement.speedo = 0;
        sbars.SetActive(false);
        dobermango.SetActive(true);
        StartCoroutine(FinishParticle());

        GoldCheck();
        StartCoroutine(THREEFIVECOROUTINE());

        StartCoroutine(Score400(3));
        StartCoroutine(Score400Coroutine());
        yallah = true;
    }
    IEnumerator Dogscore5()
    {
        yield return new WaitForSeconds(4.5f);
        a.GetComponent<StackFollow>().enabled = false;
        a.GetComponent<Stack2>().enabled = true;
        StartCoroutine(GGPanel());
        movement.speedo = 0;
        sbars.SetActive(false);
        dobermango.SetActive(true);
        StartCoroutine(FinishParticle());

        GoldCheck();
        StartCoroutine(THREEFIVECOROUTINE());

        StartCoroutine(Score500(3));
        StartCoroutine(Score500Coroutine());
        yallah = true;
    } 
    IEnumerator FinishParticle()
    {
        Llaser.Play();
        Rlaser.Play();
        yield return new WaitForSeconds(1.5f);
        Llaser.Stop();
        Rlaser.Stop();
    }
    private void GoldCheck()
    {
        int goldAmount = movement.goldScore;

        switch (goldAmount)
        {
            case 1:
                StartCoroutine(Gold1());
                break;
            case 2:
                StartCoroutine(Gold2());
                break;
            case 3:
                StartCoroutine(Gold3());
                break;
            case 4:
                StartCoroutine(Gold4());
                break;
            case 5:
                StartCoroutine(Gold5());
                break;
            default:
                break;
        }
    }
    IEnumerator ONETWOCOROUTINE()
    {
        if (!asource.isPlaying)
        {
            music.volume = 0;
            asource.PlayOneShot(drum, 0.6f);
            yield return new WaitForSeconds(3.5f);
            asource.PlayOneShot(onetwo, 0.6f);
            yield return new WaitForSeconds(3.5f);
            music.volume = 0.6f;
        }
        
    }
    IEnumerator THREEFIVECOROUTINE()
    {
        if (!asource.isPlaying)
        {
            music.volume = 0;
            asource.PlayOneShot(drum, 0.6f);
            yield return new WaitForSeconds(3.5f);
            asource.PlayOneShot(threefive, 0.6f);
            yield return new WaitForSeconds(3.5f);
            music.volume = 0.6f;
        }
       
    }
    IEnumerator Gold1()
    {
        yield return new WaitForSeconds(3);
        g1.SetActive(true);
    }
    IEnumerator Gold2()
    {
        yield return new WaitForSeconds(3);
        g1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        g2.SetActive(true);
    }
    IEnumerator Gold3()
    {
        yield return new WaitForSeconds(3);
        g1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        g2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        g3.SetActive(true);
    }
    IEnumerator Gold4()
    {
        yield return new WaitForSeconds(3);
        g1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        g2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        g3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        g4.SetActive(true);
    }
    IEnumerator Gold5()
    {
        yield return new WaitForSeconds(3);
        g1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        g2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        g3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        g4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        g5.SetActive(true);
        confettir1.SetActive(true);
        confettir2.SetActive(true);
    }
    IEnumerator Score100Coroutine()
    {
        yield return new WaitForSeconds(3);
        score100 = true;
        p100.Play();
     
    }
    IEnumerator Score200Coroutine()
    {
        yield return new WaitForSeconds(3);
        score200 = true;
        p200.Play();
    }
    IEnumerator Score300Coroutine()
    {
        yield return new WaitForSeconds(3);
        score300 = true;
        p300.Play();
    }
    IEnumerator Score400Coroutine()
    {
        yield return new WaitForSeconds(3);
        score400 = true;
        p400.Play();
    }
    IEnumerator Score500Coroutine()
    {
        yield return new WaitForSeconds(3);
        score500 = true;
        confettil1.SetActive(true);
        confettil2.SetActive(true);
        p500.Play();
    }
    IEnumerator GGPanel()
    {
        yield return new WaitForSeconds(7f);
        ggpanel.SetActive(true);
    }
    IEnumerator Score100(float time)
    {
        Vector3 originalScale = doggydog.transform.localScale;
        Vector3 destinationScale = new Vector3(3.0f, 3.0f, 3.0f);

        float currentTime = 0.0f;

        do
        {
            doggydog.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
    IEnumerator Score200(float time)
    {
        Vector3 originalScale = doggydog.transform.localScale;
        Vector3 destinationScale = new Vector3(5.0f, 5.0f, 5.0f);

        float currentTime = 0.0f;

        do
        {
            doggydog.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
    IEnumerator Score300(float time)
    {
        Vector3 originalScale = doggydog.transform.localScale;
        Vector3 destinationScale = new Vector3(7.0f, 7.0f, 7.0f);

        float currentTime = 0.0f;

        do
        {
            doggydog.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
    IEnumerator Score400(float time)
    {
        Vector3 originalScale = doggydog.transform.localScale;
        Vector3 destinationScale = new Vector3(9f, 9f, 9f);

        float currentTime = 0.0f;

        do
        {
            doggydog.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
    IEnumerator Score500(float time)
    {
        Vector3 originalScale = doggydog.transform.localScale;
        Vector3 destinationScale = new Vector3(11.0f,11.0f, 11.0f);

        float currentTime = 0.0f;

        do
        {
            doggydog.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }

}
