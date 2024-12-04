using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    private InputBehaviour instance;

    private List<Inputs> movementQueue = new List<Inputs>();
    private List<Inputs> rotationQueue = new List<Inputs>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // The reason I have this in InputBehaviour, is because it will be applied to each active block as they fall.
        // Once a new object starts falling, it will remove the instance from the previous tile.

        if(instance != null && instance != this)
        {
            // While probably not necessary, I have this here just in case the queues don't get reset for new pieces.
            movementQueue.Clear();
            rotationQueue.Clear();

            // Destroys the instance.
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // Space will instantly drop a piece to the bottom.
        {
            Inputs drop = new Inputs();
            movementQueue.Add(drop);
            drop = null;

            UnityEngine.Debug.Log("added drop movement");
        }
        if(Input.GetKeyDown(KeyCode.S)) // S will drop a piece by one tile.
        {
            Inputs down = new Inputs();
            movementQueue.Add(down);
            down = null;

            UnityEngine.Debug.Log("added down movement");
        }
        if(Input.GetKeyDown(KeyCode.A)) // A will move a piece left by one tile.
        {
            Inputs left = new Inputs();
            movementQueue.Add(left);
            left = null;

            UnityEngine.Debug.Log("added left movement");
        }
        if(Input.GetKeyDown(KeyCode.D)) // D will move a piece right by one tile.
        {
            Inputs right = new Inputs();
            movementQueue.Add(right);
            right = null;

            UnityEngine.Debug.Log("added right movement");
        }
        if(Input.GetKeyDown(KeyCode.Q)) // Q will rotate a tile left.
        {
            Inputs rotateLeft = new Inputs();
            rotationQueue.Add(rotateLeft);
            rotateLeft = null;

            UnityEngine.Debug.Log("added left rotation");
        }
        if(Input.GetKeyDown(KeyCode.E)) // E will rotate a tile right.
        {
            Inputs rotateRight = new Inputs();
            rotationQueue.Add(rotateRight);
            rotateRight = null;

            UnityEngine.Debug.Log("added right rotation");
        }

        if (movementQueue.Count > 0) // Makes sure the list isn't empty first.
        {
            //UnityEngine.Debug.Log("movement list not empty");
            MovementIteration();
        }

        if (rotationQueue.Count > 0) // Makes sure the list isn't empty first.
        {
            //UnityEngine.Debug.Log("rotation list not empty");
            RotationIteration();
        }
    }

    private void MovementIteration()
    {
        for (int i = 0; i <= movementQueue.Count; i++) // Iterate over each input stored in the queue.
        {
            if (i == movementQueue.Count) // If the end of the list has been reached, restart.
            {
                i = 0;
            }
            else
            {
                switch (movementQueue[i].ToString())
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
    }

    private void RotationIteration()
    {
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

