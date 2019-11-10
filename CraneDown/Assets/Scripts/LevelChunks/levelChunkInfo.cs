using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelChunkInfo : MonoBehaviour
{
    public float Endposition;

    [SerializeField]
    GameObject Endpoint;

    public LevelChunkClass chunk;
    // Start is called before the first frame update
    void Start()
    {
        //Endposition = Endpoint.transform.position.y;
        //Endpoint.SetActive(false);

    }
    public float GetEndPoint()
    {
        Endposition = Endpoint.transform.position.y;
        chunk.LevelChunk = gameObject;
        chunk.endPoint = Endposition;
        Endpoint.SetActive(false);
        return (Endposition);
    }

}
