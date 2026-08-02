using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDown : MonoBehaviour
{
    public float floatHeight = 0;
    public LayerMask floorMask;


    private void Start()
    {
        StartCoroutine(UpdateHeight());
    }

    private IEnumerator UpdateHeight()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, floorMask))
        {
            GetComponent<playermove>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<Rigidbody>().MovePosition(hit.point + floatHeight * Vector3.up);
            Vector3 newPos = hit.point + floatHeight * Vector3.up;
            transform.position = newPos;
            yield return null;
            GetComponent<CharacterController>().enabled = true;
            GetComponent<playermove>().enabled = true;
            
        }
        yield return null;
        StartCoroutine(UpdateHeight());
    }

}
