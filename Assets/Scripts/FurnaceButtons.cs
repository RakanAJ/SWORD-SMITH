using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceButtons : MonoBehaviour
{
    [SerializeField] private GameObject _smeltingObject;
    public GameObject SmeltingObject => _smeltingObject;

    public FurnaceManager _furnaceManager;

    private void Start()
    {
        _furnaceManager._smeltedObject = SmeltingObject.gameObject;
        
    }
}
