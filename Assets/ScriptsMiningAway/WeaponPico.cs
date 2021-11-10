﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPico : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	public	void Shoot ()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
