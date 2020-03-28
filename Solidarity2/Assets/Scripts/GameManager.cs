using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetermineTransmission(true);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DetermineTransmission(false);
        }
    }

    private void DetermineTransmission(bool value)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transmitter transmitter = hit.collider.GetComponent<Transmitter>();
            if (transmitter != null)
            {
                transmitter.Transmitting = value;
            }
        }
    }
}
