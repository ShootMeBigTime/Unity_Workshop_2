using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Camera cam;
    public GameObject pointer;
    private Vector3 destination;

    private void Awake()
    {
        destination = transform.position;
    }
    // Update is called once per frame
    void OnPanic(InputValue temp)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {

            destination = hit.point;
            StartCoroutine(Pointer());
        }

       
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
        transform.LookAt(destination);
    }
    IEnumerator Pointer()
    {
        GameObject temp = Instantiate(pointer, destination, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Destroy(temp);
        yield return null;
    }
}
