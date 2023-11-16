using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Quest",menuName ="Quest/Create New Quest")]      // this makes a quick option when you right click in the unity panel.
public class Quest : MonoBehaviour            // scriptable objects are created to store large quantities of shared data.
{
    public int id;                   // quest id
    public string questName;          // quest name for display
    public string Description;       // description of quest
    public bool isComplete;          // boolean if quest previously completed
    public bool isFinished;          // boolean if quest can be turned in
    // public bool[] objectives = new bool[] { true, false, true, false, true, false, true, false, true, false };         // boolean array to flag individual objectives as completed
    public QuestType questType;        // quest types
    public QuestGoal goalType;         // objective types

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
        checkObjectives();
    }


    public bool checkObjectives()    // check array for false objectives, return true if all objectives complete                 NOVEMBER 15TH, THIS WORKS SO FAR.
    {
        for (int i=0; i < objectives.Length; i++)
        {
            if (objectives[i] != true)
            { 
                Debug.Log("Are we even hitting this? + " + objectives[i]);
                return false; 
            }

        }
        return true;
    }
}
