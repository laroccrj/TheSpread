using UnityEngine;
using System.Collections;

public class ZombieHead : MonoBehaviour {
	
	public Zombie zombie;
	
	public void arrowHit()
	{
		zombie.Die();	
	}
}
