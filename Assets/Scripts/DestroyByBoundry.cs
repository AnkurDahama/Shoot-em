using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundry : MonoBehaviour {

	void OnTriggerExit(Collider obj)
    {
        Destroy(obj.gameObject);
    }
}
