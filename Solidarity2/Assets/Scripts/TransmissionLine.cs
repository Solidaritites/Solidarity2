using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransmissionLine : MonoBehaviour
{
    public LineRenderer LineRenderer;

    public TransmissionLink Link { get; set; }
    public TransmissionController Controller { get; set; }

    public Transmitter T1 { get; set; }
    public Transmitter T2 { get; set; }

    private void Update()
    {
        if (T1 == null || T2 == null)
        {
            T1 = Controller.Transmitters.First(t => t.Id == Link.Transmitter1);
            T2 = Controller.Transmitters.First(t => t.Id == Link.Transmitter2);
        }

        if (T1.Transmitting && T2.Transmitting)
        {
            LineRenderer.material = Controller.TransmissionMaterial;
        }
        else if (T1.Transmitting ^ T2.Transmitting)
        {
            LineRenderer.material = Controller.PotentialMaterial;
        }
        else
        {
            LineRenderer.material = Controller.DeadMaterial;
        }
    }
}
