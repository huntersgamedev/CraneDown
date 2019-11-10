using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    //Set in stone stats
    const float spawnX = -.62f;
    float spawnY=0f;
    const float spawnZ = -9.37f;


    //General Stats for generator
    [SerializeField]
    int Maxamount=10;
    [SerializeField]
    float MaxDistance=10;
    [SerializeField]
    float PreviousEndpoint;
    float NextEndpoint;


    public GameObject[] LevelchunksAvailable;

    //Keeps a list of all instantiated level sections
    public List<LevelChunkClass> chunkList = new List<LevelChunkClass>();

    public int PlayerProgress;

    public float playeryPosition;
    bool searchingForClosest;
    bool generatingNewSets;
    GameObject LastchunkSpawned;


   

    // Start is called before the first frame update
    void Start()
    {
        
        PreviousEndpoint = spawnY;
        chunkSpawner();
        GetClosestChunk();


        //GenerateLevelChunk();
    }

    // Update is called once per frame
    void Update()
    {
        playeryPosition = FindObjectOfType<elevatorDown>().gameObject.transform.position.y;

        if (PlayerProgress > 5&&!generatingNewSets)
        {
            generatingNewSets = true;
            ClearOldchunks();
        }

        if (playeryPosition <= NextEndpoint&&!searchingForClosest)
        {
            searchingForClosest = true;
            GetClosestChunk();
        }
       
        
        
        
    }



    //playerProgress tracking


    public void ClearOldchunks()
    {
        for(int i =0; i < 6; i++)
        {
            Destroy(chunkList[i].LevelChunk);
        }

        chunkList.RemoveRange(0, 5);
        PlayerProgress = 0;
        generatingNewSets = false;
        chunkSpawner();
        GetClosestChunk();
    }




    public void GetClosestChunk()
    {
        Debug.Log("running function");
        bool FirstOne = true;
        float bestobstacle = 0;

        for (int i = PlayerProgress; i < chunkList.Count; i++)
        {
            float currentEndpoint = chunkList[i].endPoint;
            float Difference = playeryPosition - currentEndpoint;


            if (currentEndpoint < playeryPosition)
            {

                NextEndpoint = currentEndpoint;
                PlayerProgress = i;
                searchingForClosest = false;
                break;



                //    if (FirstOne)
                //    {

                //        bestobstacle = Difference;
                //        FirstOne = false;
                //        PlayerProgress = i;

                //    }

                //    else
                //    {
                //        if (bestobstacle > Difference)
                //        {
                //            bestobstacle = Difference;
                //            PlayerProgress = i;
                //            NextEndpoint = currentEndpoint;
                //        }
                //    }

                //}
            }



        }

    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    //Generates an individual level chunk
    public void GenerateLevelChunk()
    {
        spawnY = Random.Range(PreviousEndpoint, PreviousEndpoint - MaxDistance);
        //Debug.Log(PreviousEndpoint);
        //Debug.Log(PreviousEndpoint - MaxDistance);

        

        GameObject ChunkToSpawn = LevelchunksAvailable[Random.Range(0, levelPieceRange())];
        while (ChunkToSpawn == LastchunkSpawned)
        {
             ChunkToSpawn = LevelchunksAvailable[Random.Range(0, levelPieceRange())];
        }
        LastchunkSpawned = ChunkToSpawn;
        GameObject SpawnedChunk = Instantiate(ChunkToSpawn);

        SpawnedChunk.transform.position = new Vector3(spawnX, spawnY, spawnZ);
        chunkList.Add(SpawnedChunk.GetComponent<levelChunkInfo>().chunk);
        PreviousEndpoint = SpawnedChunk.GetComponent<levelChunkInfo>().GetEndPoint();
        

    }
    
    
    //Repopulates Level Chunks
    public void chunkSpawner()
    {
        
        for(int i=0; Maxamount - chunkList.Count!=0; i++)
        {
           //Debug.Log(Maxamount - chunkList.Count);
            //Debug.Log(i);
            GenerateLevelChunk();
        }
    }
       

    public int levelPieceRange()
    {
        int PieceRange;
        if (FindObjectOfType<PlayerUI>().score > 20)
        {
            PieceRange = 5;
        }

        else
        {
            PieceRange = 3;
        }

        return (PieceRange);
    }
}
    
