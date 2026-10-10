using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintOnScreen : MonoBehaviour
{

    public Vector3 initPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("HintTrigger"))
        {
            transform.position = initPosition;
            GetComponent<Rigidbody>().MovePosition(initPosition);
            Debug.Log($"Item {transform.name} fell through! Resetting its position.");
        }
    }
}
