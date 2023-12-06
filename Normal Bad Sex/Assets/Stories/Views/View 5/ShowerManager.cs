using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using Fungus;

public class ShowerManager : MonoBehaviour
{
    public Flowchart flowchart;
    public Animator anim;
    private int clothingCount;
    public int ClothingCount
    {
        get
        {
            return clothingCount;
        }
        set
        {
            clothingCount = value;
            Debug.Log("Clothing count: " + clothingCount);
            if (clothingCount >= maxClothingCount)
            {
                allClothesOff = true;
                Debug.Log("All clothes off");
                flowchart.SetBooleanVariable("allClothesOff", true);
                anim.Play("5");

            }
        }
    }
    public int maxClothingCount;

    /*
    public GameObject hat;
    public GameObject jacket;
    public GameObject shirt;
    public GameObject top;
    public GameObject pants;
    public GameObject underwear;

    public bool hatOff;
    public bool pantsOff;
    public bool jacketOff;
    public bool shirtOff;
    public bool underwearOff;
    public bool topOff;
    */
    public bool allClothesOff;

    #region SingletonDeclaration 
    private static ShowerManager instance;
    public static ShowerManager FindInstance()
    {
        return instance; //that's just a singletone as the region says
    }

    void Awake() //this happens before the game even starts and it's a part of the singletone
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else if (instance == null)
        {
            //DontDestroyOnLoad(this);
            instance = this;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if all objects in array detect collision, play shower anim
    //Debug.Log("Collision detected");
}

