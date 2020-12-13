using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenarator : MonoBehaviour
{
    
    public int MazeWidth, MazeHeight;

    
    public int startx = 0, starty = 0 ,startz=0;//Maze start position
    public GameObject box, plane, LightObj;
    public int planeHeight = 0;
    public float StartLightX,StartLightZ,LightWidth,LightHeight;
    
    
    private int[,] map;
    private int row, column;
    private GameObject boxParent, planeParent, LightObjParent;
    
    // Start is called before the first frame update

    void MapGenerate(int x, int y)
    {
        map[x, y] = -1;
        bool loop = true;
        bool one=false, two=false, three=false, four=false;
       
        while (loop)
        {
            if(one == true && two==true && three==true && four == true)
            {
                loop=false;
            }
            switch (Random.Range(0, 4))
            {
                case 0:
                    if (x < row - 2 && map[x + 2, y] == 0)
                    {
                        map[x + 1, y] = -1;
                        MapGenerate(x + 2, y);
                        
                    }
                    else
                    {
                        one = true;
                    }
                    break;
                case 1:
                    if (y < column - 2 && map[x, y + 2] == 0)
                    {
                        map[x, y + 1] = -1;
                        MapGenerate(x, y + 2);

                    }
                    else
                    {
                        two = true;
                    }
                    break;
                case 2:
                    if (y > 1 && map[x, y - 2] == 0)
                    {
                        map[x, y - 1] = -1;
                        MapGenerate(x, y - 2);

                    }
                    else
                    {
                        three = true;
                    }
                    break;
                case 3:
                    if (x > 1 && map[x - 2, y] == 0)
                    {
                        map[x - 1, y] = -1;
                        MapGenerate(x - 2, y);

                    }
                    else
                    {
                        four = true;
                    }
                    break;
            }
        }
        
        
        
    }

    public void MazeGenerate() {
        MazeDelete();
        if(boxParent == null && planeParent == null)
        {
            row = MazeWidth * 2 + 1;
            column = MazeHeight * 2 + 1;

            map = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int u = 0; u < column; u++)
                {

                    if (i % 2 == 1 && u % 2 == 1)
                    {
                        map[i, u] = 0;
                    }
                    else
                    {
                        map[i, u] = 1;
                    }

                }
            }
            MapGenerate(1, 1);

            int first = 0;

            boxParent = new GameObject();
            for (int i = 0; i < row; i++)
            {
                for (int u = 0; u < column; u++)
                {
                    if (map[i, u] == 1)
                    {
                        GameObject temp = Instantiate(box, new Vector3(startx + (i) * box.GetComponent<Renderer>().bounds.size.x, 0, starty + (u) * box.GetComponent<Renderer>().bounds.size.z), Quaternion.identity);
                        if (first == 0)
                        {
                            DestroyImmediate(boxParent);
                            boxParent = temp;
                            first = 1;
                        }
                        else
                        {
                            temp.transform.parent = boxParent.transform;
                        }
                    }
                }
            }



            planeParent = Instantiate(plane, new Vector3(startx, -0.5f, starty), Quaternion.identity);
            for (float i = startx; i < row * box.GetComponent<Renderer>().bounds.size.x; i += plane.GetComponent<Renderer>().bounds.size.x)
            {
                for (float u = starty; u < column * box.GetComponent<Renderer>().bounds.size.z; u += plane.GetComponent<Renderer>().bounds.size.z)
                {
                    if (!(i == startx && u == starty))
                    {
                        GameObject temp = Instantiate(plane, new Vector3(i, -0.5f, u), Quaternion.identity);
                        temp.transform.parent = planeParent.transform;
                    }
                }
            }
        }
        

        
    }

    public void LightGenerate()
    {
       
        DestroyImmediate(LightObjParent);
        if (LightObjParent == null)
        {
            LightObjParent = Instantiate(LightObj, new Vector3(StartLightX, LightHeight, StartLightZ), Quaternion.identity);
            for (float i = StartLightX; i <= row * box.GetComponent<Renderer>().bounds.size.x; i += LightWidth)
            {
                for (float u = StartLightZ; u <= column * box.GetComponent<Renderer>().bounds.size.z; u += LightWidth)
                {
                    if (!(i == StartLightX && u == StartLightZ))
                    {
                        GameObject temp = Instantiate(LightObj, new Vector3(i, LightHeight, u), Quaternion.identity);
                        temp.transform.parent = LightObjParent.transform;
                    }
                }
            }
        }
        
    }


    public void MazeDelete()
    {
        
        DestroyImmediate(boxParent);
        DestroyImmediate(planeParent);
    }

    public void LightDelete()
    {
        DestroyImmediate(LightObjParent);
    }

    public void GenerateAll()
    {
        MazeGenerate();
        LightGenerate();
    }
    public void DeleteAll()
    {
        MazeDelete();
        LightDelete();
        
    }
    /*void Start()
    {
    
    }*/

    // Update is called once per frame
   /* void Update()
    {
        
    }*/
}


