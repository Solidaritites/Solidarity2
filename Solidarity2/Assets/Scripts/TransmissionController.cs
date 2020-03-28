using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransmissionController : MonoBehaviour
{
    public Transmitter[] Transmitters { get; private set; }

    public Material TransmissionMaterial;
    public Material PotentialMaterial;
    public Material DeadMaterial;
    public TransmissionLine TransmissionLinePrefab;
    public TransmissionLink[] TransmissionLinks;

    private void Start()
    {
        Transmitters = FindObjectsOfType<Transmitter>();

        foreach (TransmissionLink link in TransmissionLinks)
        {
            TransmissionLine line = Instantiate(TransmissionLinePrefab);
            line.Link = link;
            line.Controller = this;

            Transmitter t1 = Transmitters.First(t => t.Id == link.Transmitter1);
            Transmitter t2 = Transmitters.First(t => t.Id == link.Transmitter2);

            Vector3[] pos = new Vector3[]
            {
                Transmitters.First(t => t.Id == link.Transmitter1).transform.position,
                Transmitters.First(t => t.Id == link.Transmitter2).transform.position
            };
            
            line.LineRenderer.SetPositions(pos);
            line.LineRenderer.startWidth = .1f;
            line.LineRenderer.startWidth = .2f;

            t1.Links.Add(new Link()
            {
                Other = t2,
                TLink = link
            });

            t2.Links.Add(new Link()
            {
                Other = t1,
                TLink = link
            });
        }
    }
}

[Serializable]
public struct TransmissionLink
{
    public int Transmitter1;
    public int Transmitter2;
    public TransmissionLine Line { get; set; }
}

public class Link
{
    public Transmitter Other { get; set; }
    public TransmissionLink TLink { get; set; }
}