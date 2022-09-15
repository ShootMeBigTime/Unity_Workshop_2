using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public float rotationSpeed;
    //public float hoverSpeed;

    //[SerializeField] private float floatTimer;
    //[SerializeField] private float floatRate;
    //private bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 100.0f;
        //hoverSpeed = -0.2f;
        //floatTimer = 0.7f;
        //floatRate = 1f;
        //goingUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);

        //floatTimer += Time.deltaTime;
        //Vector3 floatDir = new Vector3(hoverSpeed, 0.0f, 0.0f);
        //transform.Translate(floatDir);

        //if (goingUp && floatTimer >= floatRate)
        //{
        //    goingUp = false;
        //    floatTimer = 0;
        //    hoverSpeed = -hoverSpeed;
        //}

        //else if (!goingUp && floatTimer >= floatRate)
        //{
        //    goingUp = true;
        //    floatTimer = 0;
        //    hoverSpeed = -hoverSpeed;
        //}
    }
}
