using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour {

	public float strength;
	public float sprit;
	public float energy;
	public int gold;

	public static PlayerProperty Instance {get; set;}
	void Start () {
		Instance = this;
	}
}
