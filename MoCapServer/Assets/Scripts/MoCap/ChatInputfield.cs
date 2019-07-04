﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatInputfield : MonoBehaviour
{

    public ChatterManager chatManager;
    private InputField inputField;

    private void Start()
    {
        inputField = GetComponent<InputField>();
    }

    public void ValueChanged()
    {
        if (inputField.text.Contains("\n"))
            chatManager.WriteMessage(inputField);
    }
}
