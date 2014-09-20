using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float cameraOffset;
	public float cameraHeight;
	private PlayerController playerController;
	// Use this for initialization
	void Start () {
		playerController = player.GetComponent <PlayerController>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		Vector3 position = new Vector3 (Mathf.Sin (playerController.rotation) * cameraOffset, cameraHeight, Mathf.Cos (playerController.rotation) * cameraOffset);
		transform.position = player.transform.position + position;

		transform.LookAt (player.transform.position);
	}
}
