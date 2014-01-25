using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour 
{
	public float maxSpeed = 10f;
	public float jumpForce = 800f;
	private bool facingRight = true;
	private bool grounded = false;
	private Animator anim;
	private Collider2D collider;
	public Transform groundCheck;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		collider = GetComponent<Collider2D>();
	}

	// Update is called every frame
	void Update()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
		if(transform.position.y < -10f)
		{
			Application.LoadLevel(Application.loadedLevel);
			//transform.position = new Vector3(-6.9f, -2.9f, 0f);
		}
	}

	// FixedUpdate is called at a set rate
	void FixedUpdate()
	{
		//check if we are on the ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		if(grounded)
		{
			collider.sharedMaterial.friction = 0.4f;
		}
		else
		{
			collider.sharedMaterial.friction = 0;
		}

		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2(maxSpeed * move, rigidbody2D.velocity.y);

		if(move > 0 && !facingRight)
		{
			Flip();
		}
		else if(move < 0 && facingRight)
		{
			Flip();
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Finish") 
		{
			Application.LoadLevel("level2");
		}
		if(col.gameObject.tag == "Saw") 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
