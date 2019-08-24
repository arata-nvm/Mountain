using UnityEngine;

public class StageMaker : MonoBehaviour
{
    public GameObject groundObject;
    public GameObject seaObject;
    public GameObject beachObject;
    public GameObject treeObject;

    public string stageFile;

    private Vector3 space = new Vector3(1.0f, 1.0f, 1.0f);

    public void Create(Vector3 basePos)
    {
        var pos = basePos;
        var currentWidth = 0;
        int height;

        var textAsset = Resources.Load(stageFile, typeof(TextAsset)) as TextAsset;
        var textData = textAsset.text;
        var parentObject = new GameObject("Stage") {tag = "Stage"};

        foreach (var c in textData)
        {
            if (char.IsNumber(c))
            {
                height = int.Parse(c.ToString());
                for (var i = 0; i < height; i++)
                {
                    putObject(groundObject, pos, parentObject);
                    pos.y += space.y;
                }
                pos.x += space.x;
                pos.y = basePos.y;
                currentWidth++;
            }
            else if (c == 's')
            {
                putObject(seaObject, pos, parentObject);
                pos.x += space.x;
                currentWidth++;
            }
            else if (c == 'b')
            {
                putObject(beachObject, pos, parentObject);
                pos.x += space.x;
                currentWidth++;
            }
            else if (c == 't')
            {
                putObject(treeObject, pos, parentObject);
                pos.x += space.x;
                currentWidth++;
            }
            else if (c == '\n')
            {
                Vector3 origin = new Vector3((float)currentWidth, 1.0f, 0f);
                pos.z -= space.z;
                pos.x -= origin.x;
                currentWidth = 0;
            }
            else if (c == '-')
            {
                pos.x += space.x;
                currentWidth++;
            }
        }
    }

    private void putObject(GameObject obj, Vector3 pos, GameObject parent)
    {
        obj = Instantiate(obj, pos, Quaternion.identity) as GameObject;
        obj.name = obj.name;
        obj.transform.parent = parent.transform;
    }

    public void Delete()
    {
        var stages = GameObject.FindGameObjectsWithTag("Stage");
        foreach (var stage in stages)
        {
            GameObject.DestroyImmediate(stage);
        }
    }



}