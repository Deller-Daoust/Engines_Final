using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    private InputBehaviour instance;

    [SerializeField] private List<Inputs> movementQueue = new List<Inputs>();
    [SerializeField] private List<Inputs> rotationQueue = new List<Inputs>();

    private bool iteratingMovement = false;
    private bool iteratingRotation = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementQueue.Clear();
        rotationQueue.Clear();
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

        if(iteratingMovement == false)
        {
            if (movementQueue.Count > 0) // Makes sure the list isn't empty first.
            {
                //UnityEngine.Debug.Log("movement list not empty");
                iteratingMovement = true;
                MovementIteration();
            }
        }

        if(iteratingRotation == false)
        {
            if (rotationQueue.Count > 0) // Makes sure the list isn't empty first.
            {
                //UnityEngine.Debug.Log("rotation list not empty");
                iteratingRotation = true;
                RotationIteration();

            }
        }
    }

    private void MovementIteration()
    {
        bool movementDone = false;

        for (int i = 0; i <= movementQueue.Count; i++) // Iterate over each input stored in the queue.
        {
            if(movementQueue.Count > 0)
            {
                switch (movementQueue[i].ToString()) // The only thing stopping this code from working, is that I need to get the name of the item in the queue.
                {                                    // This only returns Inputs because that is the type of the object. Everything works fine otherwise.
                    case "drop":
                        movementDone = movementQueue[i].Drop();

                        if (movementDone == true)
                        {
                            movementQueue.RemoveAt(i);
                            movementDone = false;
                        }
                        break;
                    case "down":
                        movementDone = movementQueue[i].Down();

                        if (movementDone == true)
                        {
                            movementQueue.RemoveAt(i);
                            movementDone = false;
                        }
                        break;
                    case "left":
                        movementDone = movementQueue[i].Left();

                        if (movementDone == true)
                        {
                            movementQueue.RemoveAt(i);
                            movementDone = false;
                        }
                        break;
                    case "right":
                        movementDone = movementQueue[i].Right();

                        if (movementDone == true)
                        {
                            movementQueue.RemoveAt(i);
                            movementDone = false;
                        }
                        break;
                }
            }    
            else
            {
                iteratingMovement = false;
                movementQueue.Clear();
                return;
            }
        }
    }

    private void RotationIteration()
    {
        bool rotationDone = false;

        for (int i = 0; i <= rotationQueue.Count; i++) // Iterate over each rotation in the queue.
        {
            if (rotationQueue.Count > 0)
            {
                switch (rotationQueue[i].ToString()) // The only thing stopping this code from working, is that I need to get the name of the item in the queue.
                {                                    // This only returns Inputs because that is the type of the object. Everything works fine otherwise.
                    case "rotateLeft":
                        rotationDone = rotationQueue[i].RotateLeft();
                        
                        if(rotationDone == true)
                        {
                            rotationQueue.RemoveAt(i);
                            rotationDone = false;
                        }

                        break;
                    case "rotateRight":
                        rotationDone = rotationQueue[i].RotateRight();

                        if (rotationDone == true)
                        {
                            rotationQueue.RemoveAt(i);
                            rotationDone = false;
                        }
                        break;
                }
            }
            else
            {
                iteratingRotation = false;
                rotationQueue.Clear();
                return;
            }
        }
    }
}

public class Inputs
{
    public bool Drop()
    {
        UnityEngine.Debug.Log("dropped");
        return true;
        
    }

    public bool Down()
    {
        UnityEngine.Debug.Log("moved down");
        return true;
    }

    public bool Left()
    {
        UnityEngine.Debug.Log("moved left");
        return true;
    }

    public bool Right()
    {
        UnityEngine.Debug.Log("moved right");
        return true;
    }

    public bool RotateLeft()
    {
        UnityEngine.Debug.Log("rotated left");
        return true;
    }

    public bool RotateRight()
    {
        UnityEngine.Debug.Log("rotated right");
        return true;
    }
}

