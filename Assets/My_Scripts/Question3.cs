using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question3 : MonoBehaviour // sub and super array
{

    int noOfSets = 2;
    [SerializeField] private InputField inputNoOfSetsField;
    [SerializeField] private InputField inputArrayfield;
    [SerializeField] private GameObject storeArrayButton;
    [SerializeField] private GameObject getSuperArrayLengthButton;

    [SerializeField] private Text  arrayDisplay, resultDisplay;

    public List<string> inputArray;

    //int[] arrToProcess = new int[10] { 7, 1, 2, 4,6, 5, 3, 8, 9, 10 };

    int superArrCount =1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GetSubArrayCount(string[] arrToProcess) // Main Logic ... condition being array should be in incremental order 
    {
        superArrCount = 1;
        bool isValid = false;
        for (int currentIndex = 0; currentIndex < arrToProcess.Length-1; currentIndex++)
        {
            if (int.Parse(arrToProcess[currentIndex]) < int.Parse(arrToProcess[currentIndex + 1]))
            {
                superArrCount++;
                isValid = true;
            }
        }
        if (!isValid)
            return 0;
        else
            return superArrCount;
    }

    public void UpdateNoOfSets()
    {
        noOfSets = int.Parse(inputNoOfSetsField.text);
        noOfSets = Mathf.Clamp(noOfSets, 1, 20); // Constraints for no of sets
        ClearAllData();
    }

    public void StoreEntry()
    {
        if (inputArrayfield.text == "")
            return;

        string obtainedArrayInput = inputArrayfield.text;
        inputArray.Add(obtainedArrayInput);
        DisplayStoredArrayOneByOne(inputArray, arrayDisplay);
        CheckForNoOfSetsAcheived();
        ClearInputFields();
    }

    public void CheckForNoOfSetsAcheived()
    {
        inputArrayfield.gameObject.SetActive(inputArray.Count < noOfSets ? true : false);
        getSuperArrayLengthButton.SetActive(inputArray.Count < noOfSets ? false : true);
    }

    void ClearInputFields()
    {
        inputArrayfield.text = "";
    }

    public void StoreArrayButtonActivator()
    {
        storeArrayButton.SetActive(inputArrayfield.text != "" ? true : false);
    }

    void DisplayStoredArrayOneByOne(List<string> obtainedIntArray, Text dispText)
    {
        string listOfArray = "";
        dispText.text = "";
        foreach (string s in obtainedIntArray)
        {
            listOfArray = listOfArray + s + "\n";
        }
        dispText.text = "Array Lists\n" + listOfArray;
    }


    public void GetSuperArrayLengthAndDisplay(Text dispText) // Will process all the input int array to display result
    {
        string listOfResult = "";
        dispText.text = "";
        for (int currentIndex = 0; currentIndex < noOfSets; currentIndex++)
        {
            listOfResult = listOfResult + GetSubArrayCount(ConvertStringToIntArr(inputArray[currentIndex])) + "\n";
        }
        dispText.text = "Super Array Length\n" + listOfResult;
        getSuperArrayLengthButton.SetActive(false);
    }

    string[] ConvertStringToIntArr(string str2Convert)
    {
        string[] obtainedIntArr = str2Convert.Split(',');
        return obtainedIntArr;
    }

    public void ClearAllData()
    {
        ClearInputFields();
        inputArray.Clear();
        arrayDisplay.text = "";
        resultDisplay.text = "";
        CheckForNoOfSetsAcheived();
    }


}
