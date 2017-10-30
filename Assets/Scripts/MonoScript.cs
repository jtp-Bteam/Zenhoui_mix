using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface MonoScript {
	void Start();

	void Update();

	void FixedUpdate();

	void Idou();

	void Kaiten();

	int GetHP();

	void OnTriggerEnter(Collider other);
}
