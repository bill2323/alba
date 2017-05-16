using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{         
	public AudioSource sfxAudioPlayer;
	public Rigidbody myBody;

	public AudioClip[] audioFiles;

	public float maxSpeed;
	public float moveAcceleration;
	public float jumpAcceleration;
	private bool isGrounded = false;
	private bool isGameOver = false;

	public float gameOverHeight = -5f;

	public float rayCastDistance = 1f;

	void FixedUpdate ()
	{
		GroundChecker ();
		ConstantMove ();
	}

	void Update()
	{


		if (transform.position.y < gameOverHeight && isGameOver == false){
			isGameOver = true;
			sfxAudioPlayer.PlayOneShot (audioFiles [2]);

		}



		if (isGrounded && (Input.GetKeyDown (KeyCode.Space) ||  Input.GetMouseButtonDown(0)))
		{
			Jump ();
		}

		Debug.DrawLine (transform.position, transform.position + Vector3.down * rayCastDistance);
	}

	void OnCollisionEnter(Collision collisionInfo)
	{  
		sfxAudioPlayer.clip = audioFiles [0];
		sfxAudioPlayer.Play();

	}

	void OnCollisionExit(Collision collisionInfo)
	{
		
	}


	void ConstantMove()
	{
		Vector3 newVelocity = myBody.velocity;

		//maqsimalurze meti agar wava
	
		if (newVelocity.z >= maxSpeed)
		{
			newVelocity.z = maxSpeed;
		}

		//maqsimaluri siswrafe
		else
		{
			newVelocity.z = newVelocity.z + moveAcceleration;
		}

		myBody.velocity = newVelocity;
	}
	void GroundChecker(){
		Ray ray = new Ray ();
		ray.origin = transform.position;
		ray.direction = Vector3.down;

		isGrounded = Physics.Raycast (ray, rayCastDistance);
		//Debug.DrawLine (transform.position, transform.position + Vector3.down * rayCastDistance);
	}

	void Jump()
	{

		Vector3 jumpVelocity = myBody.velocity;
		jumpVelocity.y = jumpVelocity.y + jumpAcceleration;
		myBody.velocity = jumpVelocity;
		sfxAudioPlayer.PlayOneShot (audioFiles [1]);
	}
}
