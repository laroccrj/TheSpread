using UnityEngine;
using System.Collections;

public class Knife : MonoBehaviour
{
	public float distance;
	
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			
			if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2))
			{
				hit.collider.SendMessage("knifeHit", hit, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	
}
