using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class LevelLoader : Singleton<LevelLoader>
{
    [SerializeField]
    List<string> Scenes = new List<string>();
    bool loading;
    protected override void Awake()
    {
        base.Awake();
        _fsm = new DJG.FSM<E_LEVELSTATES>();
        AddStates();
        AddTransitons();
        m_Instance = this;
        //Subscritions will be placed here once the event system has been implemented
    }

    //void Start()
    //{
    //    foreach(UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
    //    {
    //        string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
    //        name = name.Substring(0, name.Length - 6);
    //        Scenes.Add(name);
    //    }
    //}

    public void LoadLevelSection(string name)
    {
        loading = true;
        Application.LoadLevelAdditiveAsync(name);
        StartCoroutine(LoadSection(name));
    }

    private IEnumerator LoadSection(string name)
    {
        yield return new WaitForSeconds(.1f);
        while (loading == true)
        {
            loading = false;
        }


        StopCoroutine(LoadSection(name));
    }

    #region FSM functions
    /// <summary>
    /// Adds a list of all the states declared in the enum to keep track of all the valid states 
    /// this object can be in
    /// </summary>
    void AddStates()
    {
        foreach(int i in Enum.GetValues(typeof(E_LEVELSTATES)))
        {
            if((E_LEVELSTATES)i != E_LEVELSTATES.e_Count)
            {
                _fsm.AddState((E_LEVELSTATES)i);
            }
        }
    }

    /// <summary>
    /// Creates a list of all valid state transntions this object can complete 
    /// </summary>
    void AddTransitons()
    {
        //Valid transitions From e_Init state
        _fsm.AddTransition(E_LEVELSTATES.e_Init, E_LEVELSTATES.e_Loading);

        //Valid transitions From e_Loading state
        _fsm.AddTransition(E_LEVELSTATES.e_Loading, E_LEVELSTATES.e_DeLoad);

        //Valid transitions From e_DeLoad state
        _fsm.AddTransition(E_LEVELSTATES.e_DeLoad, E_LEVELSTATES.e_Destroying);
        _fsm.AddTransition(E_LEVELSTATES.e_DeLoad, E_LEVELSTATES.e_Loading);

        //Valid transitions From e_Destroying
        _fsm.AddTransition(E_LEVELSTATES.e_Destroying, E_LEVELSTATES.e_Loading);
        _fsm.AddTransition(E_LEVELSTATES.e_Destroying, E_LEVELSTATES.e_Exit); 
    }
    #endregion

    #region Varibales
    /// <summary>
    /// Enum to keep track of the states that are corresponding to the 
    /// LevelLoader system
    /// </summary>
    enum E_LEVELSTATES
    {
        e_Init,             //State at creation
        e_Loading,          //State at which a level is loading
        e_DeLoad,           //The unloading of a level
        e_Destroying,       //Destorying of objects in a scene that will no need to be reloaded at the current state
        e_Exit,             //Shutting down of the level loader
        e_Count             //keeps track of the size of the enum
    }

    //Variable of type FSM the variable type is defined in the namesapce DJG
    DJG.FSM<E_LEVELSTATES> _fsm;

    //Creates a private varibale of the class as the varibale type to create a refrence to an instance of this class
    private LevelLoader m_Instance;

    //Protected varibale that returns a refrence to this instance of the class
    protected LevelLoader Instance
    {
        get
        {
            return m_Instance;
        }
    }
    #endregion
}
