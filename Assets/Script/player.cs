using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player: MonoBehaviour
{
	[SerializeField] private CharacterController2D controller;
	[SerializeField] private Transform playerTransform;
	[SerializeField] private Animator anim;

	[SerializeField] private int countDwd;
	
	[SerializeField] private float runSpeed;

	[SerializeField] private Text count;

	[SerializeField] private int level;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		count.text = countDwd.ToString();

		level = PlayerPrefs.GetInt("levelAt");

	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;

	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Dewandaru"))
		{
			Destroy(other.gameObject);
			countDwd++;
		}
	}

	private void saveProgress()
	{
		PlayerPrefs.SetInt("levelAt", 1);
	}
}
