
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
	//variables
	public float swerweSpeed;
	public GameObject character,stack,startbutton,scorebars,go,pausepanel,choco,chococlose,finger,fingerbar,pausebut,nameobj,bt1,bt2,bt3,bt4,bt5,bt6,levels;
	public float moveSpeed,score,speedo,turnSpeed,b;
	private Rigidbody characterBody;
	Transform parentPickup;
	[SerializeField] Transform stackPosition,rotate;
	public Text scoretext,goldtext,totalcoin;
	public AudioSource asource;
	public AudioClip pickup,coin,button;
	public int goldScore,dogscore;
	public bool gameStarted,collidertrigger;
	[SerializeField] ParticleSystem coinpartclie;
	Animator anim;
	[SerializeField] Animator goldanim;




	// Use this for initialization
	void Start()
	{
		
		totalcoin.text = PlayerPrefs.GetInt("totalcoin").ToString();
		anim = character.GetComponent<Animator>();
		characterBody = character.GetComponent<Rigidbody>();
	}

    public void PlayerSpeed(float pS)
    {
		moveSpeed = pS;
    }
	void Update()
	{

        if (gameStarted ==true)
        {
			transform.position -= Vector3.forward * Time.deltaTime * moveSpeed;

            if (dogscore <= 0)
            {
				dogscore = 0;
            }
		}
	}
	public void Pause()
    {
		gameStarted = false;
		anim.SetTrigger("gamepaused");
		pausepanel.SetActive(true);
		asource.PlayOneShot(button, 0.8f);	
	}
	public void Unpause()
	{
		pausepanel.SetActive(false);
		gameStarted = true;
		anim.SetTrigger("running");
		asource.PlayOneShot(button, 0.8f);
	}
	public void Bonus()
    {
		choco.SetActive(true);
		chococlose.SetActive(true);

	}
	public void BonusClose()
	{
		choco.SetActive(false);
		chococlose.SetActive(false);
	}
	public void Touchtostart()
    {
		gameStarted = true;
		scorebars.SetActive(true);
		startbutton.SetActive(false);
		anim.SetTrigger("running");
		fingerbar.SetActive(false);
		finger.SetActive(false);
		pausebut.SetActive(true);
		nameobj.SetActive(false);
		levels.SetActive(false);
		totalcoin.gameObject.transform.parent.gameObject.SetActive(false);
	}
	IEnumerator ColliderCoroutine()
    {
		yield return new WaitForSeconds(1);
		collidertrigger = false;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pickup"))
		{
			collidertrigger = true;
			StartCoroutine(ColliderCoroutine());
			dogscore += 1;
			scoretext.text = dogscore.ToString("0") + "x";


			switch (dogscore)
			{
				case 6:
					bt6.SetActive(true);
					break;
				case 5:
					bt5.SetActive(true);
					break;
				case 4:
					bt4.SetActive(true);
					break;
				case 3:
					bt3.SetActive(true);
					break;
				case 2:
					bt2.SetActive(true);
					break;
				case 1:
					bt1.SetActive(true);
					break;
				default:
					break;
			}

			score += 100;
			Transform otherTransform = other.transform;
			Rigidbody otherRb = otherTransform.GetComponent<Rigidbody>();
			otherRb.isKinematic = true;


			other.transform.RotateAround(other.transform.position, Vector3.up, 180);

			asource.PlayOneShot(pickup, 0.6f);
			other.gameObject.GetComponent<BoxCollider>().isTrigger = false;

			if (parentPickup == null)
			{
				parentPickup = go.transform;
				other.transform.Rotate(0, 180, 0);
				parentPickup.position = stackPosition.position;
				parentPickup.parent = stackPosition;
				dogscore -= 1;
				scoretext.text = dogscore.ToString("0") + "x";

			}

			else
			{
				parentPickup.position += Vector3.forward * (otherTransform.localScale.y + 0.2f);
				otherTransform.position = stackPosition.position;
				otherTransform.parent = parentPickup;

			}
		}

		if (other.gameObject.CompareTag("Gold"))
		{
			int value = PlayerPrefs.GetInt("totalcoin");
			value += 1;
			PlayerPrefs.SetInt("totalcoin", value);
			goldanim.SetTrigger("gold");
			coinpartclie.Play();
			asource.PlayOneShot(coin, 0.8f);
			goldScore += 1;
			goldtext.text = goldScore.ToString("0");
			Destroy(other.gameObject);
		}
	}
}

