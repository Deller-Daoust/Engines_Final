using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TetrominoFactory : MonoBehaviour
{
    [SerializeField] private GameObject L_Cube;
    [SerializeField] private GameObject T_Cube;
    [SerializeField] private GameObject J_Cube;
    [SerializeField] private GameObject S_Cube;
    [SerializeField] private GameObject Z_Cube;
    [SerializeField] private GameObject O_Cube;
    [SerializeField] private GameObject I_Cube;

    // Cubes representing the shapes. All blocks are input in the factory object as they are serialized.
    [SerializeField] private List<GameObject> L_Blocks;
    [SerializeField] private List<GameObject> T_Blocks;
    [SerializeField] private List<GameObject> J_Blocks;
    [SerializeField] private List<GameObject> S_Blocks;
    [SerializeField] private List<GameObject> Z_Blocks;
    [SerializeField] private List<GameObject> O_Blocks;
    [SerializeField] private List<GameObject> I_Blocks;

    [SerializeField] List<List<GameObject>> ObjectPool;

    private float SpawnTimer = 0;
    private float DestroyTimer = 0;

    private int random = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 70; i++)
        {
            if(i <= 10) // Adding 10 L Blocks to the pool
            {
                L_Blocks = new List<GameObject>();

                for(int l = 0; l < 4; l ++)
                {
                    L_Blocks.Add(L_Cube);
                    Instantiate(L_Blocks[l]);
                }
                
                ObjectPool.Add(L_Blocks);
            }
            else if(i > 10 && i <= 20) // Adding 10 T Blocks to the pool
            {
                T_Blocks = new List<GameObject>();

                for (int l = 0; l < 4; l++)
                {
                    T_Blocks.Add(T_Cube);
                    Instantiate(T_Blocks[l]);
                }

                ObjectPool.Add(T_Blocks);
            }
            else if(i > 20 && i <= 30) // Adding 10 J Blocks to the pool
            {
                J_Blocks = new List<GameObject>();

                for (int l = 0; l < 4; l++)
                {
                    J_Blocks.Add(J_Cube);
                    Instantiate(J_Blocks[l]);
                }

                ObjectPool.Add(J_Blocks);
            }
            else if(i > 30 && i <= 40) // Adding 10 S Blocks to the pool
            {
                S_Blocks = new List<GameObject>();

                for (int l = 0; l < 4; l++)
                {
                    S_Blocks.Add(S_Cube);
                    Instantiate(S_Blocks[l]);
                }

                ObjectPool.Add(S_Blocks);
            }
            else if(i > 40 && i <= 50) // Adding 10 Z Blocks to the pool
            {
                Z_Blocks = new List<GameObject>();

                for (int l = 0; l < 4; l++)
                {
                    Z_Blocks.Add(Z_Cube);
                    Instantiate(Z_Blocks[l]);
                }

                ObjectPool.Add(Z_Blocks);
            }
            else if(i > 50 && i <= 60) // Adding 10 O Blocks to the pool
            {
                O_Blocks = new List<GameObject>();

                for (int l = 0; l < 4; l++)
                {
                    O_Blocks.Add(O_Cube);
                    Instantiate(O_Blocks[l]);
                }

                ObjectPool.Add(O_Blocks);
            }
            else if(i > 60 && i < 70) // Adding 10 I Blocks to the pool
            {
                I_Blocks = new List<GameObject>();

                for (int l = 0; l < 4; l++)
                {
                    I_Blocks.Add(I_Cube);
                    Instantiate(I_Blocks[l]);
                }

                ObjectPool.Add(I_Blocks);
            }

            for (int j = 0; j < 4; j++)
            {
                ObjectPool[i][j].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer = Time.deltaTime * 100;
        DestroyTimer = Time.deltaTime * 100;

        if(SpawnTimer >= 10)
        {
            random = Random.Range(1, 70);

            // ObjectPool[random][x].AddComponent<InputBehaviour>(); 
            // Where x is whatever piece that is getting enabled (0, 1, 2, 3, like below).
            // And each piece gets given InputBehaviour so that the pieces can be controlled.
            ObjectPool[random][0].SetActive(true);
            ObjectPool[random][1].SetActive(true);
            ObjectPool[random][2].SetActive(true);
            ObjectPool[random][3].SetActive(true);
        }

        if(DestroyTimer >= 9)
        {
            // ObjectPool[random][x].RemoveComponent<InputBehaviour>(); 
            // Where x is whatever piece that is getting disabled (0, 1, 2, 3, like below).
            // And each piece has InputBehaviour removed so that the pieces can no longer be controlled.
            ObjectPool[random][0].SetActive(false);
            ObjectPool[random][1].SetActive(false);
            ObjectPool[random][2].SetActive(false);
            ObjectPool[random][3].SetActive(false);
        }
    }
}
