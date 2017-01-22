using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class My_Interactable : MonoBehaviour {

    public UnityEvent onHighlight, onDeHighlight, onSelect;
    public float maxRange = 5;
    protected bool objectHighlighted = false;

	// Use this for initialization
	void Start () {
		
	}

}