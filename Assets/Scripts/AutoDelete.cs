using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDelete : MonoBehaviour {
    public GameObject ob;
	// Use this for initialization
	void Start () {
        Destroy(ob, 2);
	}
	
}
