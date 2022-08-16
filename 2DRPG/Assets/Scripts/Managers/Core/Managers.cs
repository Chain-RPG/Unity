using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers manager;
    public static Managers Manager { get { init(); return manager; } }

    #region Core
    InputManager input = new InputManager();
    public static InputManager Input { get { return Manager.input; } }

    ResourceManager resource = new ResourceManager();
    public static ResourceManager Resource { get { return Manager.resource; } }

    UIManager ui = new UIManager();
    public static UIManager UI { get { return Manager.ui; } }

    SceneManagerEx scene = new SceneManagerEx();
    public static SceneManagerEx Scene { get { return Manager.scene; } }

    DataManager data = new DataManager();
    public static DataManager Data { get { return Manager.data; } }
    #endregion

    #region Contents
    NetworkManager network = new NetworkManager();
    public static NetworkManager Network { get { return Manager.network; } }
    #endregion

    static void init()
    {
        if(manager == null)
        {
            GameObject go = GameObject.Find("@Manager");
            if(go == null)
            {
                go = new GameObject() { name = "@Manager" };
                go.AddComponent<Managers>();
            }
            manager = go.GetComponent<Managers>();
            GameObject.DontDestroyOnLoad(go);

            Manager.network.init();
        }
    }

    public void Clear()
    {

    }

    void Start()
    {
        init();
    }

    void Update()
    {
        ProcessingQueue.Processor.Flush();
    }
}
