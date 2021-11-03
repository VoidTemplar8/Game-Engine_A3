using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<CommandInterface> commandBuffer = new Queue<CommandInterface>();

    static List<CommandInterface> commandHistory = new List<CommandInterface>();
    static int counter = 0;

    private bool dirtyflagbool;

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
        
        //Assignment 3 DirtyFlag
        if (dirtyflagbool == true)
        {
            List<string> lines = new List<string>();

            foreach (CommandInterface c in commandHistory)
            {
                lines.Add(c.ToString());
            }

            System.IO.File.WriteAllLines(Application.dataPath + "/SaveFile.txt", lines);

            dirtyflagbool = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            dirtyflagbool = true;
        }
    }
}
