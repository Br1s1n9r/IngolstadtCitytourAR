using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class CodeInputChanger : MonoBehaviour
{
    [CanBeNull] public InputField prevInput;
    [CanBeNull] public InputField nextInput;
    private InputField currentInput;
    private string inputNumber;


    // Start is called before the first frame update
    void Start()
    {
        currentInput = gameObject.GetComponent<InputField>();
        inputNumber = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (inputNumber == "" && Input.GetKeyDown(KeyCode.Backspace))
             {
                 if (prevInput != null)
                 {
                     prevInput.Select();
                 }
             }
        
        if (inputNumber != currentInput.text)
        {
            if (inputNumber.Length == 1 && currentInput.text.Length == 0)
            {
            }
            else
            {
                if (nextInput != null)
                {
                    nextInput.Select();
                }
            }

            inputNumber = currentInput.text;
        }

        
    }
}