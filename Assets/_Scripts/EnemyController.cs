using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public float speed = 100f;

	// PRIVATE INSTANCE VARIABLES
	private Rigidbody2D _rigidBody2D;
	private Transform _transform;
	private Animator _animator;

	private bool _isGrounded = false;

	// Use this for initialization
	void Start () {
		this._rigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// check if enemy is grounded
		if (this._isGrounded) {
			this._animator.SetInteger ("AnimState", 1);
			this._rigidBody2D.velocity = new Vector2 (this.speed, 0f);
		} else {
			this._animator.SetInteger ("AnimState", 0);
		}
	}

	void OnCollisionStay2D(Collision2D otherCollider) {
		if (otherCollider.gameObject.CompareTag ("Platform")) {
			this._isGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D otherCollider) {
		if (otherCollider.gameObject.CompareTag ("Platform")) {
			this._isGrounded = false;
		}
	}

	private void _flip() {
		if (this._transform.localScale.x == 1) {
			this._transform.localScale = new Vector3 (-1f, 1f, 1f);
		} else {
			this._transform.localScale = new Vector3 (1f, 1f, 1f);
		}
	}
}
