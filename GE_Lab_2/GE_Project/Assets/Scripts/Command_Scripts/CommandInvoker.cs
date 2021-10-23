using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<CommandInterface> commandBuffer;

    static List<CommandInterface> commandHistory;
    static int counter;

    private void Awake()
    {
        commandBuffer = new Queue<CommandInterface>();
        commandHistory = new List<CommandInterface>();
    }
    public static void AddCommand(CommandInterface command)
    {
        while (commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }

        commandBuffer.Enqueue(command);
    }
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            CommandInterface c = commandBuffer.Dequeue();
            c.Execute();

            //commandBuffer.Dequeue().Execute();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Command history length: " + commandHistory.Count);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (counter > 0)
                {
                    counter--;
                    commandHistory[counter].Undo();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (counter < commandHistory.Count)
                {
                    commandHistory[counter].Execute();
                    counter++;
                }
            }
        }
    }
}
