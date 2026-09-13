using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    public float timeToDestruct;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(playerDestory), timeToDestruct);
    }


    void playerDestory()
    {
        var children = transform.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            child.transform.parent = null;
            child.gameObject.AddComponent<Rigidbody>();
            child.gameObject.AddComponent<BoxCollider>();
            child.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(10f, 51f), Random.Range(10f, 20f), Random.Range(10f, 50f)));
            child.GetComponent<Rigidbody>().useGravity = true;
        }
        Destroy(GetComponent<CharacterController>());
        Destroy(GetComponent<Rigidbody>());
    }
}
