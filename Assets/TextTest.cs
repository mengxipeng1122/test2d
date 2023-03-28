using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public struct Button
{
    public string name;
    public int id;
    public int value;
}

public class TextTest : MonoBehaviour
{
    private TextMeshProUGUI myTextMeshPro;
    private Button[] btns;
    private string[] axes;
    
    // Start is called before the first frame update
    void Start()
    {
        myTextMeshPro = GetComponent<TextMeshProUGUI>();

        btns = new Button[] {
            new Button { name = "A",        id=0 , value=0},
            new Button { name = "B",        id=1 , value=0},
            new Button { name = "X",        id=2 , value=0},
            new Button { name = "Y",        id=3 , value=0},
            new Button { name = "L",        id=4 , value=0},
            new Button { name = "R",        id=5 , value=0},
            new Button { name = "L1",       id=6 , value=0},
            new Button { name = "R1",       id=7 , value=0},
            new Button { name = "Select",   id=10, value=0},
            new Button { name = "Start",    id=11, value=0},
        };

        axes = new string []{
            "Left"        ,
            "Right"       ,
            "GamePad"     ,
        };
    }

    // Update is called once per frame
    void Update()
    {
        //foreach(Button b in btns)
        for(int t=0; t<btns.Length; t++) {
            Button b = btns[t];
            string key = "joystick button "+b.id;
            if(Input.GetKeyDown(key)){ btns[t].value=1; }
            if(Input.GetKeyUp(key))  { btns[t].value=0; }
        }

        UpdateText();
    }

    void UpdateText()
    {
        string s="";
        foreach (string key in axes) {
            s += key + " " ;
            s += Input.GetAxis(key+"X") + " ";
            s += Input.GetAxis(key+"Y") + " ";
            s += "\n";
        }
        foreach (Button b in btns) {
            string key = b.name;
            s += key + " " + b.value + '\n';
        }
        myTextMeshPro.text = s;
    }
}
