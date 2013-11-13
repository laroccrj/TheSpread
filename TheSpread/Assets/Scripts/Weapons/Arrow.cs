using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
	public float flyTime;
	public Collider childCollider;
	
	private bool flying = true;
	private float stopTime;
	private Transform anchor;
	
	void Start()
	{
		this.stopTime = Time.time + this.flyTime;
	}
	
	void Update ()
	{
		if(this.stopTime <= Time.time && this.flying)
		{
			GameObject.Destroy(gameObject);	
		}
		
		if(this.flying)
		{
			this.rotate();	
		} 
		else if(this.anchor != null)
		{
			this.transform.position = anchor.transform.position;
			this.transform.rotation = anchor.transform.rotation;
		}
		
	}
	
	void OnCollisionEnter(Collision collision)
	{	
		if(this.flying)
		{
			this.flying = false;
			this.transform.position = collision.contacts[0].point;
			this.childCollider.isTrigger = true;
				
			GameObject anchor = new GameObject("ARROW_ANCHOR");
			anchor.transform.position = this.transform.position;
			anchor.transform.rotation = this.transform.rotation;
			anchor.transform.parent = collision.transform;
			this.anchor = anchor.transform;
			
			Destroy(rigidbody);
			collision.gameObject.SendMessage("arrowHit", SendMessageOptions.DontRequireReceiver);
		}
	}
	
	void rotate()
	{	
		
		transform.LookAt(transform.position + rigidbody.velocity);
		
	}
}
