using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public PlayerEntity playerEntity;
    public PlayerMotion PlayerMotion;
    public GameObject playerGameObject;
    public GameObject[] tilePrefabs;
    public float zpawn = 0;
    public float tileLenght = 30f;
    public int numberofTiles = 3;
    //public InterfaceManager interfaceManager;
    public Transform playerTransform;
    public List<GameObject> activeTiles = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
      
        for (int i = 0; i < numberofTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            SpawnTile(Random.Range(1, tilePrefabs.Length));
        }
        playerTransform = FindObjectOfType<PlayerEntity>().transform;
        PlayerMotion = FindObjectOfType<PlayerMotion>();
        playerEntity = FindObjectOfType<PlayerEntity>();
        playerGameObject = FindObjectOfType<PlayerEntity>().gameObject;
    }

   
    void Update()
    {
        if (playerTransform.position.z -35 > zpawn - (numberofTiles * tileLenght))
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zpawn, transform.rotation);
        activeTiles.Add(go);
        zpawn += tileLenght;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

}
