using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Quest",menuName ="Quest/Create New Quest")]      // this makes a quick option when you right click in the unity panel.
public class Quest : ScriptableObject            // scriptable objects are created to store large quantities of shared data.
{
    public int id;                   // quest id
    public string questName;          // quest name for display
    public string Description;       // description of quest
    public bool isComplete;          // boolean if quest previously completed
    public bool isFinished;          // boolean if quest can be turned in
    public bool[] objectives;        // boolean array to flag individual objectives as completed
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
    }
    public bool checkObjectives(Quest.objectives[])    // check array for false objectives, return true if all objectives complete
    {
        for (int i=0; i < objectives.Length; i++)
        {
            if (objectives[i] != true)
            { 
                Debug.log(objectives[i]);
                return false; 
            }

        }
        return true;
    }
}
