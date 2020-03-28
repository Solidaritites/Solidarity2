using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmitter : MonoBehaviour
{
    public int Id;
    public bool Transmitting;

    public List<Link> Links { get; set; }

    private void Awake()
    {
        Links = new List<Link>();
    }
}
