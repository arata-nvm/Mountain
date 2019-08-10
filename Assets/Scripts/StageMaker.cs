using System.IO;
using UnityEngine;

public class StageMaker : MonoBehaviour {
    public GameObject groundObject;
    public GameObject seaObject;
    public GameObject beachObject;
    public GameObject treeObject;

    private Vector3 space = new Vector3(1.0f, 1.0f, 1.0f);    

    void Start () {
    }

    public void Create(Vector3 basePos) {
        Vector3 pos = basePos;
        int currentWidth = 0;
        int height;

        TextAsset textAsset = new TextAsset();
        textAsset = Resources.Load("Stages/Stage1", typeof(TextAsset)) as TextAsset;
        string textData = textAsset.text;
        GameObject parentObject = new GameObject("Stage");
        parentObject.tag = "Stage";

        foreach(char c in textData) {
            if (char.IsNumber(c)) {
                height = int.Parse(c.ToString());
                for (int i = 0; i < height; i++) {
                    putObject(groundObject, pos, parentObject);
                    pos.y += space.y;
                }
                pos.x += space.x;
                pos.y = basePos.y;
                currentWidth++;
            } else if (c == 's') {
                putObject(seaObject, pos, parentObject);
                pos.x += space.x;
                currentWidth++;
            } else if (c == 'b') {
                putObject(beachObject, pos, parentObject);
                pos.x += space.x;
                currentWidth++;
            } else if (c == 't') {
                putObject(treeObject, pos, parentObject);
                pos.x += space.x;
                currentWidth++;
            } else if (c == '\n') {
                Vector3 origin = new Vector3((float)currentWidth, 1.0f, 0f);
                pos.z -= space.z;
                pos.x -= origin.x;
                currentWidth = 0;
            } else if (c == '-') {
                pos.x += space.x;
                currentWidth++;
            }
        }
    }

    private void putObject(GameObject obj, Vector3 pos, GameObject parent) {
        obj = Instantiate(obj, pos, Quaternion.identity) as GameObject;
        obj.name = beachObject.name;
        obj.transform.parent = parent.transform;
    }

    public void Delete() {
        GameObject[] stages = GameObject.FindGameObjectsWithTag("Stage");
        foreach(GameObject stage in stages) {
            GameObject.DestroyImmediate(stage);
        }
    }

    
	
}