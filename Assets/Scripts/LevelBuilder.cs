using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
	public Transform player;
	public GameObject[] platforms;
	public int numberOfStartingPlatforms;
	public float destroyTime = 5f; //destroy platforms after some time
	public Vector3 platformSpawnPoint = Vector3.zero;

	//-------------------- Unity Functions: ------------------------------------
	void Start()
	{
		int counter = 0;

		//create starting platforms
		while (counter < numberOfStartingPlatforms)
		{
			CreateNextPlatform ();
			counter = counter + 1;
		}
	}

	int pp;
	int lastPP = 0;
	void Update()
	{
		//number of 50 meter segments passed
		pp = (int) player.position.z / 50;

		//if moving to a new segment
		if (pp > lastPP) 
		{
			//create a new platform
			CreateNextPlatform ();
		}

		lastPP = pp;
	}

	//-------------------- My Custom Functions ------------------------------------
	void CreateNextPlatform()
	{
		Debug.Log ("Creating Platform");

		//move spawn position on z axis
		platformSpawnPoint.z = platformSpawnPoint.z + 50f;

		//randomly choose a platfrom
		int platformChooser = Random.Range(0, platforms.Length);

		//create a new GameObject
		GameObject clone;
		clone = Instantiate ( platforms[ platformChooser ] );

		//move the new GameObject to spawn position
		clone.transform.position = platformSpawnPoint;

		//destroy the object after some time
		Destroy (clone, destroyTime);
	}
}
