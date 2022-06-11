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

	[SerializeField] private string allDwd;
	
	[SerializeField] private float runSpeed;

	[SerializeField] private Text count;

	[SerializeField] private int level;

	private SceneSwitcher sw;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	void Start()
	{
		sw = new SceneSwitcher();
	}

	void Update()
	{

		resetProgress();

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

		count.text = countDwd.ToString() + " " + allDwd  ; 

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

		}else if (other.gameObject.CompareTag("ClearLevel"))
		{
			saveProgress();
            StartCoroutine(waitBeforeMoveScene());
		}
	}

	private void saveProgress()
	{
		PlayerPrefs.SetInt("levelAt", 1);
	}

	private void resetProgress()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
            PlayerPrefs.SetInt("levelAt", 0);

		}
	}

	IEnumerator waitBeforeMoveScene()
	{
		sw.moveToCurrentLevel();
		yield return new WaitForSeconds(3);
	}
}
