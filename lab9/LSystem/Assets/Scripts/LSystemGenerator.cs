using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemGenerator : MonoBehaviour
{
    private Dictionary<char, string> rules = new Dictionary<char, string>();
    private string currentString;
    public float len = 10.0f;
    public int depth = 5;
    public Color[] colors = {Color.red, Color.yellow, Color.green, Color.cyan,
        Color.blue, Color.magenta, Color.white};

    public enum SystemType
    {
        TutorialSystem,
        BinaryTree,
        KochCurve,
        SierpinskiTri,
        DragonCurve,
        BarnsleyFern,
        HilbertCurve
    };
    public SystemType systemType = SystemType.TutorialSystem;

    private Stack<TransformInfo> transStack = new Stack<TransformInfo>();
    private bool isGenerating = false;
    private string axiom;
    private float angle;
    void Start()
    {
        if(systemType == SystemType.TutorialSystem)
        {
            rules.Add('F', "FF+[+F-F-F]-[-F+F+F]");
            axiom = "F";
            angle = 25f;
        }
        else if(systemType == SystemType.SierpinskiTri)
        {
            rules.Add('F', "F-G+F+G-F");
            rules.Add('G', "GG");
            axiom = " F-G-G";
            angle = 120f;
        }
        else if(systemType == SystemType.KochCurve)
        {
            rules.Add('F', "F+F-F-F+F");
            axiom = "F";
            angle = 90f;
        }
        else if (systemType == SystemType.BinaryTree)
        {
            rules.Add('1', "11");
            rules.Add('0', "1[0]0");
            axiom = "0";
            angle = 45f;
        }
        else if (systemType == SystemType.DragonCurve)
        {
            rules.Add('X', "X+YF+");
            rules.Add('Y', "-FX-Y");
            axiom = "FX";
            angle = 90f;
        }
        else if (systemType == SystemType.BarnsleyFern)
        {
            rules.Add('X', "F+[[X]-X]-F[-FX]+X");
            rules.Add('F', "FF");
            axiom = "X";
            angle = 25f;
        }
        else if (systemType == SystemType.HilbertCurve)
        {
            rules.Add('X', "+YF-XFX-FY+");
            rules.Add('Y', "-XF+YFY+FX-");
            axiom = "X";
            angle = 90f;
        }
        currentString = axiom;
        StartCoroutine(GenerateLSystem());
    }

    int count = 0;
    IEnumerator GenerateLSystem()
    {
        while (count < depth)
        {
            if(!isGenerating)
            {
                isGenerating = true;
                StartCoroutine(Generate());
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator Generate()
    {
        string newString = "";

        char[] stringCharacters = currentString.ToCharArray();

        foreach (char i in stringCharacters)
        {
            if(rules.ContainsKey(i))
            {
                newString += rules[i];
            }
            else
            {
                newString += i.ToString();
            }
            
        }
        currentString = newString;
        Debug.Log(currentString);
        stringCharacters = currentString.ToCharArray();
        foreach (char i in stringCharacters)
        {
            if (systemType == SystemType.TutorialSystem)
            {
                if (i == 'F')
                {
                    Vector3 initPos = transform.position;
                    transform.Translate(Vector3.forward * len);
                    Debug.DrawLine(initPos, transform.position, colors[count % colors.Length], 10000f, false);
                    yield return null;
                }
                else if (i == '+')
                {
                    transform.Rotate(Vector3.up * angle);
                }
                else if (i == '-')
                {
                    transform.Rotate(Vector3.up * -angle);
                }
                else if (i == '[')
                {
                    TransformInfo ti = new TransformInfo();
                    ti.position = transform.position;
                    ti.rotation = transform.rotation;
                    transStack.Push(ti);
                }
                else if (i == ']')
                {
                    TransformInfo ti = transStack.Pop();
                    transform.position = ti.position;
                    transform.rotation = ti.rotation;
                }
            }
            else if (systemType == SystemType.SierpinskiTri)
            {
                if (i == 'F')
                {
                    Vector3 initPos = transform.position;
                    transform.Translate(Vector3.forward * len);
                    Debug.DrawLine(initPos, transform.position, colors[count % colors.Length], 10000f, false);
                    yield return null;
                }
                else if (i == 'G')
                {
                    Vector3 initPos = transform.position;
                    transform.Translate(Vector3.forward * len);
                    Debug.DrawLine(initPos, transform.position, colors[count % colors.Length], 10000f, false);
                    yield return null;
                }
                else if (i == '-')
                {
                    transform.Rotate(-angle * Vector3.up);
                }
                else if (i == '+')
                {
                    transform.Rotate(Vector3.up * angle);
                }
            }
            else if (systemType == SystemType.KochCurve)
            {
                if (i == 'F')
                {
                    Vector3 initPos = transform.position;
                    transform.Translate(Vector3.forward * len);
                    Debug.DrawLine(initPos, transform.position, colors[count % colors.Length], 10000f, false);
                    yield return null;
                }
                else if (i == '-')
                {
                    transform.Rotate(angle * Vector3.up);
                }
                else if (i == '+')
                {
                    transform.Rotate(Vector3.up * -angle);
                }
            }
            else if (systemType == SystemType.BinaryTree)
            {
                if (i == '0')
                {
                    Vector3 initPos = transform.position;
                    transform.Translate(Vector3.forward * len);
                    Debug.DrawLine(initPos, transform.position, colors[count % colors.Length], 10000f, false);
                }
                else if (i == '1')
                {
                    Vector3 initPos = transform.position;
                    transform.Translate(Vector3.forward * len);
                    Debug.DrawLine(initPos, transform.position, colors[count % colors.Length], 10000f, false);
                }
                else if (i == '[')
                {
                    TransformInfo ti = new TransformInfo();
                    ti.position = transform.position;
                    ti.rotation = transform.rotation;
                    transStack.Push(ti);
                    transform.Rotate(angle * Vector3.up);
                    Debug.Log("push");
                }
                else if (i == ']')
                {
                    TransformInfo ti = transStack.Pop();
                    transform.position = ti.position;
                    transform.rotation = ti.rotation;
                    transform.Rotate(-angle * Vector3.up);
                    Debug.Log("pop");
                }
                yield return null;
            }
            else if (systemType == SystemType.DragonCurve)
            {
                if (i == 'F')
                {
                    Vector3 initPos = transform.position;
                    transform.Translate(Vector3.forward * len);
                    Debug.DrawLine(initPos, transform.position, colors[count % colors.Length], 10000f, false);
                    yield return null;
                }
                else if (i == '-')
                {
                    transform.Rotate(angle * Vector3.up);
                }
                else if (i == '+')
                {
                    transform.Rotate(Vector3.up * -angle);
                }
            }
            if (systemType == SystemType.BarnsleyFern)
            {
                if (i == 'F')
                {
                    Vector3 initPos = transform.position;
                    transform.Translate(Vector3.forward * len);
                    Debug.DrawLine(initPos, transform.position, colors[count % colors.Length], 10000f, false);
                    yield return null;
                }
                else if (i == '+')
                {
                    transform.Rotate(Vector3.up * angle);
                }
                else if (i == '-')
                {
                    transform.Rotate(Vector3.up * -angle);
                }
                else if (i == '[')
                {
                    TransformInfo ti = new TransformInfo();
                    ti.position = transform.position;
                    ti.rotation = transform.rotation;
                    transStack.Push(ti);
                }
                else if (i == ']')
                {
                    TransformInfo ti = transStack.Pop();
                    transform.position = ti.position;
                    transform.rotation = ti.rotation;
                }
            }
            else if (systemType == SystemType.HilbertCurve)
            {
                if (i == 'F')
                {
                    Vector3 initPos = transform.position;
                    transform.Translate(Vector3.forward * len);
                    Debug.DrawLine(initPos, transform.position, colors[count % colors.Length], 10000f, false);
                    yield return null;
                }
                else if (i == '-')
                {
                    transform.Rotate(-angle * Vector3.up);
                }
                else if (i == '+')
                {
                    transform.Rotate(Vector3.up * angle);
                }
            }

        }
        count++;
        if(systemType != SystemType.DragonCurve)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }
        if(systemType == SystemType.BinaryTree || systemType == SystemType.BarnsleyFern 
            || systemType == SystemType.TutorialSystem || 
            systemType == SystemType.SierpinskiTri || systemType == SystemType.HilbertCurve)
        {
            len = len / 2.0f;
        }
        isGenerating = false;
    }
}
