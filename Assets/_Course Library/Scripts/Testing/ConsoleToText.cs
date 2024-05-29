using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleToText : MonoBehaviour
{
    public Text debugText;
    string output = "";
    string stack = "";

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (debugText != null)
        {
            output = logString + "\n" + output;
            stack = stackTrace;
            debugText.text = output; // Update the debugText here
        }
    }

    public void ClearLog()
    {
        output = "";
        if (debugText != null)
        {
            debugText.text = output; // Clear the debugText when ClearLog is called
        }
    }
}
