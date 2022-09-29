using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Paper got picked up");
            PlayerController temp = other.GetComponent<PlayerController>();
            temp.notes =+ 1;
            Destroy(this.gameObject);
        }
    }
}
