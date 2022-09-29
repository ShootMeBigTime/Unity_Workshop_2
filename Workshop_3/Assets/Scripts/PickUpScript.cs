using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject givenItem;
    public void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            Debug.Log("Test");
            other.GetComponent<Backpack>().items.Add(givenItem);
            this.gameObject.active = false;
        }
    }
}
