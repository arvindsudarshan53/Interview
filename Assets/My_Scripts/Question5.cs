using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question5 : MonoBehaviour // Finds Duplicate in list of Array
{
    public List<int> intArray;

    [SerializeField] private InputField inputFieldForIntArray;

    [SerializeField] private Text normalList, listWithOutDuplicate;

    int maxListCount = 1000;

    public void AddIntToArray()
    {
        if (inputFieldForIntArray.text == "" && intArray.Count > maxListCount)
            return;
        int obtainedVal = int.Parse(inputFieldForIntArray.text);
        intArray.Add(obtainedVal);
        inputFieldForIntArray.text = "";
        DisplayListArray();
    }

    public void FindDuplicateEntry() //Main Logic...
    {
        var listWithoutDuplicateTemp = intArray.Distinct().ToList(); // eliminates duplicate from list
        string withoutDuplicateStr = "";
        foreach(int i in listWithoutDuplicateTemp)
        {
            withoutDuplicateStr = withoutDuplicateStr + i+"\n";
        }
        listWithOutDuplicate.text = "Without Duplicate\n" + withoutDuplicateStr;
    }

    public void DisplayListArray()
    {
        string listStr = "";
        foreach (int i in intArray)
        {
            listStr = listStr + i+"\n";
        }
        normalList.text = "Normal Array\n" + listStr;
    }

    public void ClearAllData()
    {
        inputFieldForIntArray.text = "";
        normalList.text = "";
        listWithOutDuplicate.text = "";
        intArray.Clear();

    }

}
