using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Question1 : MonoBehaviour // Print "Hello" for multiples of 3 and "World" for multiples of 5
{

    [SerializeField] private InputField inputNumField;
    [SerializeField] private Text outputDisp;

    int n = 5;

    public void UpdateInputNumField()
    {
        n = int.Parse(inputNumField.text);
    }

    public void GetOutput()
    {
        outputDisp.text = "";
        string combinedStr = "";
        for(int currentIndex = 1; currentIndex <=n; currentIndex++)
        {
            if(currentIndex %3 == 0)
            {
                // Print "Hello"
                combinedStr = combinedStr + "Hello\n";
                outputDisp.text = combinedStr;
            }
            else if (currentIndex % 5 == 0)
            {
                // Print "World"
                combinedStr = combinedStr + "World\n";
                outputDisp.text = combinedStr;
            }
            else
            {
                combinedStr = combinedStr + currentIndex + "\n";
                outputDisp.text = combinedStr;
            }
        }
    }
}
