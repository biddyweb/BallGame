using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	private int count;
	public float rotation;
	public float rotationSpeed;

	void Start()
	{
		count = 0;
		rotation = 0;
		setCountText ();
	}
	void FixedUpdate()
	{
		checkReset();
		
		float turnDirection = Input.GetAxis ("Horizontal");
		float moveDirection = Input.GetAxis ("Vertical");

		rotation += turnDirection * rotationSpeed;

		Vector3 movement = new Vector3 (Mathf.Sin (rotation), 0, Mathf.Cos (rotation));

		rigidbody.AddForce (movement * moveDirection * speed* Time.deltaTime);
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

	void checkReset()
	{
		//Fallen Off
		if (rigidbody.position.y < -20)
		{
			rigidbody.position = new Vector3(0,0.5f,0);
			rigidbody.velocity = new Vector3(0,0,0);
		}
	}
}