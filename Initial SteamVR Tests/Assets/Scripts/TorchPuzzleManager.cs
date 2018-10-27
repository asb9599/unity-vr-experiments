using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TorchPuzzleManager : MonoBehaviour
{
    // Public Variables
    public DoorControl doorControl;
    public List<Torch> torches;
    // Private Variables
    private bool puzzleSolved = false;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		// Make sure puzzle has not yet been solved
        if (puzzleSolved == false)
        {
            // Check if all torches have been lit
            if (torches.All(torch => torch.isLit == true))
            {
                // Set puzzleSolved to true
                puzzleSolved = true;
                // Send a message to open the door
                doorControl.Open();
                // Close the door after 10 seconds
                doorControl.Invoke("Close", 10);
            }
        }
	}
}
