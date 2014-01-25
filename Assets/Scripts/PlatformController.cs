using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour
{
	private Animator charAnim;
	private bool grounded;
	private Collider2D collider;

	// Use this for initialization
	void Start () 
	{
		charAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
		collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		grounded = charAnim.GetBool("Ground");
		if(grounded)
		{
			collider.sharedMaterial.friction = 0.4f;
		}
		else
		{
			collider.sharedMaterial.friction = 0;
		}
	}
}
