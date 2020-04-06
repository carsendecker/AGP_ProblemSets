using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using SimpleJSON;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

[ExecuteInEditMode]
public class Week7 : MonoBehaviour
{
    /*
     * Below are a series of problems to solve with recursion.  You may need to make additional functions to do so.
     * Do not solve these problems with loops.
     */

    // Return the reversed version of the input.
    public string ReverseString(string toReverse)
    {
        return ReverseString(toReverse, "");
    }

    private string ReverseString(string toReverse, string newString)
    {
        if (toReverse.Length == 0)
            return newString;

        char nextChar = toReverse[toReverse.Length - 1];

        return ReverseString(toReverse.Remove(toReverse.Length - 1), newString += nextChar);
    }

    // Return whether or not the string is a palindrome
    public bool IsPalindrome(string toCheck)
    {
        if(ReverseString(toCheck).ToLower().Equals(toCheck.ToLower()))
            return true;
        
        return false;
    }

    List<string> charStrings = new List<string>();
    // Return all strings that can be made from the set characters using all characters.
    public string[] AllStringsFromCharacters(params char[] characters)
    {
        //**Got kinda stuck on this one, ended up putting myself in a weird corner and have worked on it for a while so im just leaving it unfinished in shame**
        charStrings.Clear();
        //Commented out so the other tests will work
        // AllStringsFromCharacters(characters.ToString(), "");
        return charStrings.ToArray();
    }

    private void AllStringsFromCharacters(string characters, string currentStr)
    {
        if (characters.Length == 0)
            charStrings.Add(currentStr);
        
        for(int i = 1; i <= characters.Length; i++)
        {
            AllStringsFromCharacters(characters.Substring(0, i)
                                     + characters.Substring(i, characters.Length - i),currentStr + characters[i-1]);
        }
        
        
    }

    public int SumOfAllNumbers(params int[] numbers)
    {
        return SumOfAllNumbers(numbers, 0);
    }

    private int SumOfAllNumbers(int[] numbers, int index)
    {
        if (index >= numbers.Length)
            return 0;
        
        return numbers[index] + SumOfAllNumbers(numbers, ++index);
    }

    /*
     * Solve the following problem with recursion:
     *
     * A new soda company is doing a promotion - they'll buy back cans.  But they're not sure how much to charge per can,
     * or how much to pay out for cans.  Write a function that can determine how many cans someone can purchase for
     * a given amount of money, assuming they always return all the cans and then buy as much soda as they can.
     */

    public int TotalCansPurchasable(float money, float price, float canRefund)
    {
        return TotalCansPurchasable(money, price, canRefund, 0);
    }

    private int TotalCansPurchasable(float money, float price, float canRefund, int cansBought)
    {
        if (money < price) return cansBought;

        return TotalCansPurchasable((money - price) + canRefund, price, canRefund, ++cansBought);
    }
    
    
    // =========================== DON'T EDIT BELOW THIS LINE =========================== //

    public TextMeshProUGUI recursionTest, sodaTest;
    
    private void Update()
    {
        recursionTest.text =  "Recursion Problems\n<align=left>\n";
        recursionTest.text += Success(ReverseString("TEST") == "TSET") + " string reverser worked correctly.\n";
        recursionTest.text += Success(!IsPalindrome("TEST") && IsPalindrome("ASDFDSA") && IsPalindrome("ASDFFDSA")) + " palindrome test worked correctly.\n";
        recursionTest.text += Success(AllStringsFromCharacters('A', 'B').Length == 2 && AllStringsFromCharacters('A').Length == 1 && AllStringsFromCharacters('A', 'B', 'C').Length == 6 && AllStringsFromCharacters('A', 'B', 'C', 'D', 'E', 'F', 'G').Length == 5040) + " palindrome test worked correctly.\n";
        recursionTest.text += Success(SumOfAllNumbers(1, 2, 3, 4, 5) == 15 && SumOfAllNumbers(1, 2, 3, 4, 5, 6, 7) == 28) + " sum test worked correctly.\n";

        sodaTest.text = "Soda Problem\n<align=left>\n";
        
        sodaTest.text += Success(TotalCansPurchasable(4, 2, 1) == 3) + " soda test works correctly w/out change.\n";
        sodaTest.text += Success(TotalCansPurchasable(5, 2, 1) == 4) + " soda test works correctly w/change.\n";
    }

    private string Success(bool test)
    {
        return test ? "<color=\"green\">PASS</color>" : "<color=\"red\">FAIL</color>";
    }
}