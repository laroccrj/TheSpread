using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public void Die()
	{
		Destroy(gameObject);	
	}
	
	public void knifeHit(RaycastHit hit)
	{
		Vector3 contactPoint = transform.TransformPoint(hit.point);

		if(contactPoint.z < 0)
		{
			this.Die();
		}
	}
}
