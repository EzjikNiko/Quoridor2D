using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuoridorElement : MonoBehaviour
{
    public QuoridorApplication app { get { return GameObject.FindObjectOfType<QuoridorApplication>(); } }
}

public class QuoridorApplication : MonoBehaviour
{
    public QuoridorModel model;
    public QuoridorView view;
    public QuoridorController controller;

    void Start()
    {

    }
}
