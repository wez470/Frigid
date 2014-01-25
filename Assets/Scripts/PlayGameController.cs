using UnityEngine;
using System.Collections;

public class PlayGameController : MonoBehaviour
{
	private Animator anim;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void OnMouseEnter()
	{
		anim.SetBool("hover", true);
	}

	void OnMouseExit()
	{
		anim.SetBool("hover", false);
		anim.SetBool("press", false);
	}

	void OnMouseDown()
	{
		anim.SetBool("press", true);
	}

	void OnMouseUpAsButton()
	{
		Application.LoadLevel("level1");
	}
}
