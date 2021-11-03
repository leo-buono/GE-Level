using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<CommandInterface> commandBuffer = new Queue<CommandInterface>();

    static List<CommandInterface> commandHistory = new List<CommandInterface>();
    static int counter = 0;

    //dirty flag - bool check
    private bool dirty_;

    private void Awake()
    {
        commandBuffer = new Queue<CommandInterface>();
        commandHistory = new List<CommandInterface>();

        //initialized to false while no changes are being made
        dirty_ = false;
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

        // if the dirty flag is true, check which commands are taking place
        if (dirty_)
        {
            List<string> lines = new List<string>();

            foreach(CommandInterface c in commandHistory)
            {
                lines.Add(c.ToString());
            }

            System.IO.File.WriteAllLines(Application.dataPath + "/dataSavingIsFun.txt", lines);

            dirty_ = false;
        }

        // press ctrl + f to print events in the .txt file, then refresh assets folder
        if (Input.GetKeyDown(KeyCode.F))
        {
            dirty_ = true;
        }
      
    }
}
