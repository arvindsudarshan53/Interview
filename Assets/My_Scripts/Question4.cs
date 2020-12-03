using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question4 : MonoBehaviour
{

    [SerializeField] private InputField inputExpressionField;
    [SerializeField] private Text resultText;

    string expressionStr = "123+*";//"34*2+23+*";

    public char[] charArrFromObtainedExpression;

    public List<int> numbersStack = new List<int>();
    int currentStackIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        inputExpressionField.text = expressionStr;
        charArrFromObtainedExpression = expressionStr.ToCharArray();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void AddToNumberStack(int item) // Pushes value to Stack
    {
        numbersStack.Add(item);
        print("Added " + item);
    }


    int GetValueFromStackAndRemove() // Pops value from Stack
    {
        int itemToReturn = numbersStack[numbersStack.Count - 1];
        numbersStack.RemoveAt(numbersStack.Count - 1);
        print("Removed "+itemToReturn);
        return itemToReturn;
    }

    int val;
    char ch;

    void SolveThisExpression(char[] postfix) //Main Logic...
    {
        
        int topMostValFromStack, secondTopMostValFromStack;
        for (int currentIndex = 0; currentIndex < postfix.Length; currentIndex++)
        {
            ch = postfix[currentIndex];
            //print("Digit");
            if (IsNumber(ch))
            {
                print("Digit");
                AddToNumberStack(int.Parse(ch.ToString()));
            }
            else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
            {
                print("Not Digit");
                topMostValFromStack = GetValueFromStackAndRemove();
                secondTopMostValFromStack = GetValueFromStackAndRemove();

                switch (ch) /* ch is an operator */
                {
                    case '*':
                        val = secondTopMostValFromStack * topMostValFromStack;
                        break;

                    case '/':
                        val = secondTopMostValFromStack / topMostValFromStack;
                        break;

                    case '+':
                        val = secondTopMostValFromStack + topMostValFromStack;
                        break;

                    case '-':
                        val = secondTopMostValFromStack - topMostValFromStack;
                        break;
                }

                AddToNumberStack(val);
            }
        }
        if(numbersStack.Count > 0)
            resultText.text = "Result = "+GetValueFromStackAndRemove();
    }

    public void Execute()
    {
        SolveThisExpression(charArrFromObtainedExpression); 
    }


    public void UpdateInputNumField()
    {
        //charArrFromObtainedExpression.Clear();
        expressionStr = inputExpressionField.text;
        charArrFromObtainedExpression = expressionStr.ToCharArray();
    }

    bool IsNumber(char c)
    {
        int number;
        if (int.TryParse(c.ToString(), out number))
        {
            return true;
        }
        else
            return false;

    }
}
