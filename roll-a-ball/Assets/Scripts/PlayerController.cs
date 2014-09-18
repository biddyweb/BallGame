using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	private int count;
	

	void Start()
	{
		count = 0;
		setCountText ();
	}
	void FixedUpdate()
	{
		if (rigidbody.position.y < -20)
		{
			rigidbody.position = new Vector3(0,0.5f,0);
			rigidbody.velocity = new Vector3(0,0,0);
		}
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		
		Vector3 movement = new Vector3 (horizontalMovement, 0, verticalMovement);

		rigidbody.AddForce (movement * speed* Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Pickup")
		{
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
		}
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count == 4)
			winText.text = "YOU WIN!";
	}
}