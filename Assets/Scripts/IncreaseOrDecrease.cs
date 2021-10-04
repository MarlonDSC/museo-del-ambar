using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IncreaseOrDecrease : MonoBehaviour
{
    int number;
    public TextMeshProUGUI n;
    public void increment()
    {
        number = int.Parse(n.text);
        if (number >= 0)
        {
            number++;
            n.text = number.ToString();
        }
        //return n;
    }
    
    public void decrement()
    {
        number = int.Parse(n.text);
        if(number > 0)
        {
            number--;
            n.text = number.ToString();
        }
        //return n;
    }
}
