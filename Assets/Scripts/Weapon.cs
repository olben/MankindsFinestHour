﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	#region MEMBERS
	public GameObject bullet;
	public Transform shootSpawn;

	private bool b_shootRight;
	private GameObject m_clone;
	private float f_bulletSpeed = 25f;
	private Transform m_transform;
	private Vector3 v_shootDirection;
	private Movement m_movement;
	private float f_angle = 0f;
	#endregion


	void Start () {
		m_transform = transform;
		m_movement = GetComponent<Movement>();
		v_shootDirection = m_transform.right;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawLine(m_transform.position, shootSpawn.position);
		b_shootRight = m_movement.facingRight;
		if(Input.GetKey(KeyCode.LeftControl))
			ShootNormalGun();
	}

	void ShootNormalGun(){
		m_clone = Instantiate(bullet, shootSpawn.position, Quaternion.identity) as GameObject;
		m_clone.rigidbody2D.velocity = (shootSpawn.position - m_transform.position).normalized * f_bulletSpeed;
		Destroy(m_clone, 5f);
	}
	void ShootSpecialGun(){

	}
	void MeleeAttack(){

	}

	public void MoveShootingTarget(float axis){
		f_angle = axis * 45f;

		shootSpawn.position = m_transform.position;
		if(b_shootRight)
			shootSpawn.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * f_angle), Mathf.Sin(Mathf.Deg2Rad * f_angle),  0f) * 2f;
		else
			shootSpawn.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * f_angle) * -1, Mathf.Sin(Mathf.Deg2Rad * f_angle),  0f) * 2f;
	}
	/*public void MoveShootingTarget(float axis){
		if((angle < 90 || axis == -1) && (angle > -90 || axis == 1))
			angle += axis * Time.deltaTime * 100f;
		if(angle > 90f) angle = 90f;
		if(angle < -90f) angle = -90f;
		shootSpawn.position = m_transform.position;
		if(shootRight)
			shootSpawn.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle),  0f) * 2f;
		else
			shootSpawn.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle) * -1, Mathf.Sin(Mathf.Deg2Rad * angle),  0f) * 2f;
	}*/
}
