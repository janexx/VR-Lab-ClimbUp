using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/*
 * In diesem Skript wird ein Text-Element referenziert, in dem die Konsolen-Ausgaben angezeigt werden sollen. 
 * Die HandleLog-Methode wird aufgerufen, wenn eine Nachricht an die Konsole gesendet wird, und fügt diese dem Text-Element hinzu.
 * */

public class DebugConsole : MonoBehaviour
{
    public Text consoleText;

    private void Start()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        consoleText.text += $"{type.ToString()}: {logString}\n";
    }
}