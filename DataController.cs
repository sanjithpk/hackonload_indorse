using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{

    public KnightController knightController;
    public delegate void NDelegate();


    RootObject obj;
    Grammar grammer;
    string path;
    string jsonString;
    int index=0;
    int counter = 0;

    void Start()
    {
        converter();
      

    }

    void callback()
    {

        counter += 1;
        Debug.Log(counter);
        nextAction(counter);

    }

    void nextAction(int counter)
    {
        grammer = obj.getGrammar(counter);
        Debug.Log(grammer);

        // find objet which needs to be sent the information.
        grammer.Noun;
        knightController.knight(grammer.ToString(),callback);


    }


    // Update is called once per frame
    public Grammar converter()
    {
        var textFile = Resources.Load<TextAsset>("output");
        Debug.Log(textFile.text);
        obj = JsonUtility.FromJson<RootObject>(textFile.text);
        Debug.Log(obj.ToString());
        grammer = obj.getGrammar(0);
        Debug.Log(grammer);

       // knightController = new KnightController();
        knightController.knight(grammer.Verb, callback);
    
        return grammer;

    }

    public void StartNewTask(Grammar grammar, NDelegate nDelegate)
    {

        Debug.Log("I have started new Task.");
       // if (nDelegate != null)
            //nDelegate("I have completed Task.");
    }



    void Update()
    {
        
    }
}
