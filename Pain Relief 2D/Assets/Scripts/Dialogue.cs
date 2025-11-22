using System.Collections;//using of ArrayList
using System.Collections.Generic; //enable using of lists, queues...
using UnityEngine;

[System.Serializable] //editable and visible in inspector
//host all information about a single dialogue
public class Dialogue
{
    public string name; //name of NPC talking

    [TextArea(1,3)] //min and max amount of line of text (in inspector)
    public string[] sentences; //sentences that will load into queue (a list/array of strings)
}
