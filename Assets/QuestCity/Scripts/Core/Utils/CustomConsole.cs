using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using System.Text;

namespace QuestCity.Core.Utils
{
    public class CustomConsole : MonoBehaviour
    {
        public TextMeshProUGUI ConsoleText;

        public int maxLines = 8;
        private Queue<string> queue = new Queue<string>();
        private string currentText = "";

        private void OnEnable()
        {
            Application.logMessageReceivedThreaded += HandleLog;
        }

        void HandleLog(string logString, string stackTrace, LogType type)
        {
            if (queue.Count >= maxLines) queue.Dequeue();

            queue.Enqueue(logString);

            var builder = new StringBuilder();
            foreach (string st in queue)
            {
                builder.Append(st).Append("\n");
            }

            ConsoleText.text = builder.ToString();
        }

    }
}