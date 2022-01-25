using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GlobalVariableControl : MonoBehaviour
{
    public static GlobalVariableControl Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        GameObject.FindGameObjectWithTag("Username").gameObject.GetComponent<Text>().text = GlobalVariableControl.Instance.username;
    }

    public string username;

    enum LANGUAGE
    {
        DE,
        EN
    };

    public void SetUsername()
    {
        Text UsernameInput = GameObject.FindGameObjectWithTag("Username").gameObject.GetComponent<Text>();
        
        if (UsernameInput)
        {
            GlobalVariableControl.Instance.username = UsernameInput.text;
        }

        Debug.Log("Username is: " + username);
    }
}