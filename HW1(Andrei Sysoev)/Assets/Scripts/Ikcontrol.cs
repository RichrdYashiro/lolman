using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikcontrol : MonoBehaviour
{
	public Transform Point;
	public Transform x;
	private Animator animator;
	public bool ikActive;
	public float distance;
	

	public Transform lookObj = null;

	


	void Start()
	{
		Point = lookObj;
		animator = GetComponent<Animator>();
		distance = Vector3.Distance(x.position, Point.position);
		if (distance >= 2)
		{
			ikActive = false;
		}


		else
		{
			ikActive = true;

		}
	}

	void OnAnimatorIK()
	{
        
		if (ikActive)
		{
			if (lookObj != null)
			{
				animator.SetLookAtWeight(1, 1, 1, 1, 1);
				animator.SetLookAtPosition(lookObj.position);
			}
		}
	}
}
