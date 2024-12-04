using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    private List<Inputs> movementQueue;
    private List<Inputs> rotationQueue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // Space will instantly drop a piece to the bottom.
        {
            Inputs drop = new Inputs();
            movementQueue.Add(drop);
            drop = null;
        }
        if(Input.GetKeyDown(KeyCode.S)) // S will drop a piece by one tile.
        {
            Inputs down = new Inputs();
            movementQueue.Add(down);
            down = null;
        }
        if(Input.GetKeyDown(KeyCode.A)) // A will move a piece left by one tile.
        {
            Inputs left = new Inputs();
            movementQueue.Add(left);
            left = null;
        }
        if(Input.GetKeyDown(KeyCode.D)) // D will move a piece right by one tile.
        {
            Inputs right = new Inputs();
            movementQueue.Add(right);
            right = null;
        }
        if(Input.GetKeyDown(KeyCode.Q)) // Q will rotate a tile left.
        {
            Inputs rotateLeft = new Inputs();
            rotationQueue.Add(rotateLeft);
            rotateLeft = null;
        }
        if(Input.GetKeyDown(KeyCode.E)) // E will rotate a tile right.
        {
            Inputs rotateRight = new Inputs();
            rotationQueue.Add(rotateRight);
            rotateRight = null;
        }

        for (int i = 0; i <= movementQueue.Count; i++) // Iterate over each input stored in the queue.
        {
            if(i == movementQueue.Count) // If the end of the list has been reached, restart.
            {
                i = 0;
            }
            else
            {
                switch(movementQueue[i].ToString())
                {
                    case "drop":
                        movementQueue[i].Drop(); 
                        break;
                    case "down":
                        movementQueue[i].Down();
                        break;
                    case "left":
                        movementQueue[i].Left();
                        break;
                    case "right":
                        movementQueue[i].Right();
                        break;
                }
            }
        }

        for (int i = 0; i <= rotationQueue.Count; i++) // Iterate over each rotation in the queue.
        {
            if (i == rotationQueue.Count) // If the end of the list has been reached, restart.
            {
                i = 0;
            }
            else
            {
                switch (rotationQueue[i].ToString())
                {
                    case "rotateLeft":
                        rotationQueue[i].RotateLeft();
                        break;
                    case "rotateRight":
                        rotationQueue[i].RotateRight();
                        break;
                }
            }
        }

    }
}

public class Inputs
{
    public void Drop()
    {
        UnityEngine.Debug.Log("dropped");
    }

    public void Down()
    {
        UnityEngine.Debug.Log("moved down");
    }

    public void Left()
    {
        UnityEngine.Debug.Log("moved left");
    }

    public void Right()
    {
        UnityEngine.Debug.Log("moved right");
    }

    public void RotateLeft()
    {
        UnityEngine.Debug.Log("rotated left");
    }

    public void RotateRight()
    {
        UnityEngine.Debug.Log("rotated right");
    }
}

