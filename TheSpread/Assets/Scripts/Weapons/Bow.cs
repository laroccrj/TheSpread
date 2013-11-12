using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour
{
	public float maxPower;
	public float powerIncreaseRate;
	public GameObject arrow;
	public Collider origin;
	
	private bool pulling = false;
	private float power = 0;
	
	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, 100, 50), this.power.ToString());	
	}
	
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			this.startPull();
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			this.stopPull();
		}
		
		if(pulling){
			power += powerIncreaseRate;
			
			if(power > maxPower) power = maxPower;
		}
	}
	
	private void startPull()
	{
		this.pulling = true;
		this.power = 0;
	}
	
	private void stopPull()
	{
		this.pulling = false;
		this.fire();
	}
	
	private void fire()
	{
		GameObject arrow = this.spawnArrow();
		
		arrow.rigidbody.AddRelativeForce(Vector3.forward * this.power);
		
	}
	
	private GameObject spawnArrow()
	{
		Vector3 start = transform.position;
		Quaternion rotation = transform.rotation;
		
		GameObject obj = (GameObject)GameObject.Instantiate(this.arrow, start, rotation);
		Arrow arrow = obj.GetComponent<Arrow>();
		Physics.IgnoreCollision(this.origin, arrow.childCollider);
		
		return obj;
	}
}
