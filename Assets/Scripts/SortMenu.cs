using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SortMenu : MonoBehaviour
{
    public ObjectManager _selectionSort;
    public ObjectManager _activeSorter;
    public TMP_InputField _inputNumberOfCubes;

    public void StartSort() 
    {
        _activeSorter = Instantiate(_selectionSort);
        _activeSorter._numberOfCubes = Convert.ToInt32(_inputNumberOfCubes.text);
        _activeSorter.StartSort();
    }

    public void ResetSort() 
    { 
        Destroy(_activeSorter.gameObject);
    }
       
}
