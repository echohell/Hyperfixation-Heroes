using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Quest : MonoBehaviour            // scriptable objects are created to store large quantities of shared data.
{
    public int id;                   // quest id
    public string questName;          // quest name for display
    public string Description;       // description of quest
    public bool isComplete;          // boolean if quest previously completed
    public bool isFinished;          // boolean if quest can be turned in
    public bool[] objectives;         // boolean array to flag individual objectives as completed
    public QuestType questType;        // quest types
    public QuestGoal goalType;         // objective types

    public void Start()
    {
        objectives = new bool[] { true, false, true, false, true, false, true, false, true, false };        // instantiates the values of this specific bool array.
    }

    public enum QuestType             // can be expanded at a later time to include other values like gold and gems
    {
        Main, Side, Repeatable, Daily
    }

    public enum QuestGoal
    {
        Kill, Collect, GoTo, Interact
    }

    public void Update() 
    { 
        if (isComplete != true) checkObjectives();                                  // just a quick dirty check to make sure the function is complete.
    }


    public void checkObjectives()    // check array for false objectives, return true if all objectives complete                 NOV 15TH, THIS WORKS SO FAR. NOV 16th UPDATED TO WORK AS INTENDED.
    {

        for (int i = 0; i < objectives.Length; i++)                                     // simple for loop
        {
            if (objectives[i] != true)                                              // iterate through i integer
            { 
                Debug.Log("Are we even hitting this? + " + objectives[i]);          // spit out if it is false
            }
            else
            {
                Debug.Log("We are hitting this? + " + objectives[i]);               // spit out if it is true
            }
        }
        isComplete = true;                                                          // finish the function
    }

    // Previous code block was public bool checkObjectives. It did not correctly return true or false because there was a blank area.
    // isComplete just got highjacked to end the function, it can be changed to it's own variable at any time.
    // Previous function just finished the for loop and then returned true anyway which is, just, not correct.

    // Commenting old block to compare for later.

    /*
     * 
     * public bool checkObjectives()    // check array for false objectives, return true if all objectives complete                 NOVEMBER 15TH, THIS WORKS SO FAR.
     *  {
     *      for (int i=0; i < objectives.Length; i++)
     *      {
     *          if (objectives[i] != true)
     *          {
     *              Debug.Log("Are we even hitting this? + " + objectives[i]);
                    return false;
                }

            return true;
            }
        }
    */
}
