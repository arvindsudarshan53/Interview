using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question2 : MonoBehaviour // anagram checker
{
    int noOfSets = 2;

    [SerializeField] private InputField inputNoOfSetsField;
    [SerializeField] private InputField inputName1Field;
    [SerializeField] private InputField inputName2Field;
    [SerializeField] private GameObject addNamesButton;
    [SerializeField] private GameObject checkAnagramButton;

    [SerializeField] private Text names1ArrayDisp,names2ArrayDisp, resultArrayDisp;

    public List<string> names1StringArray, names2StringArray;

    public void UpdateNoOfSets()
    {
        noOfSets = int.Parse(inputNoOfSetsField.text);
        noOfSets = Mathf.Clamp(noOfSets, 1, 100);
        ClearAllData();
    }

    public void AddNamesToList()
    {
        if (inputName1Field.text == "" || inputName2Field.text == "")
            return;
        string obtainedName1 = inputName1Field.text;
        string obtainedName2 = inputName2Field.text;

        names1StringArray.Add(obtainedName1);
        names2StringArray.Add(obtainedName2);
        DisplayNamesOneByOne(names1StringArray, names1ArrayDisp);
        DisplayNamesOneByOne(names2StringArray, names2ArrayDisp);
        CheckForNoOfSetsAcheived();
        ClearInputNameFields();
    }

    public void AddNamesButtonActivator()
    {
         addNamesButton.SetActive(inputName1Field.text != "" && inputName2Field.text != ""? true : false);
    }

    void ClearInputNameFields()
    {
        inputName1Field.text = "";
        inputName2Field.text = "";
    }

    public void CheckForNoOfSetsAcheived()
    {
        inputName1Field.gameObject.SetActive(names1StringArray.Count < noOfSets ? true : false);
        inputName2Field.gameObject.SetActive(names2StringArray.Count < noOfSets ? true : false);
        checkAnagramButton.SetActive(names2StringArray.Count < noOfSets ? false : true);
    }

    void DisplayNamesOneByOne(List<string> obtainedNameArray, Text dispText)
    {
        string listOfNames = "";
        dispText.text = "";
        foreach (string s in obtainedNameArray)
        {
            listOfNames = listOfNames + s + "\n";
        }
        dispText.text = "Names\n"+listOfNames;
    }


    string IsThisAnagram(string name1, string name2)
    {
        char[] ch1 = name1.ToLower().ToCharArray();
        char[] ch2 = name2.ToLower().ToCharArray();
        System.Array.Sort(ch1);
        System.Array.Sort(ch2);
        string val1 = new string(ch1);
        string val2 = new string(ch2);

        if (val1 == val2)
        {
            return "Yes";
        }
        else
        {
            return "No";
        }
    }

    public void CheckForAnagramAndDispResults(Text dispText)
    {
        string listOfResult = "";
        dispText.text = "";
        for(int currentIndex = 0; currentIndex < noOfSets; currentIndex++)
        {
            listOfResult = listOfResult + IsThisAnagram(names1StringArray[currentIndex],names2StringArray[currentIndex]) + "\n";
        }
        dispText.text = "Is these Anagram\n"+listOfResult;
        checkAnagramButton.SetActive(false);
    }

    public void ClearAllData()
    {
        ClearInputNameFields();
        names1StringArray.Clear();
        names2StringArray.Clear();
        names1ArrayDisp.text = "";
        names2ArrayDisp.text = "";
        resultArrayDisp.text = "";
        CheckForNoOfSetsAcheived();
    }


}
