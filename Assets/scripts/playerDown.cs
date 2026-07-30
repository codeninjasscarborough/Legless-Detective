using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDown : MonoBehaviour
{
    public float floatHeight = 0;
    public LayerMask floorMask;

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, floorMask))
        {
            GetComponent<CharacterController>().enabled = false;
            GetComponent<Rigidbody>().MovePosition(hit.point + floatHeight * Vector3.up);
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
