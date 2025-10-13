using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //editable in inspector
//host all information about a single dialogue
public class Dialogue
{
    public string name; //name of NPC talking

    [TextArea(1,3)] //min and max amount of line of text (in inspector)
    public string[] sentences; //sentences that will load into queue
}
