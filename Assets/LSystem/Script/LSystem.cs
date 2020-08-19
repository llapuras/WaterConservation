﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LSystem : MonoBehaviour
{
    
    public Dictionary<char, string> rules = new Dictionary<char, string>();

    [Header("Plant Units")]
    public GameObject S;
    public GameObject P;
    public GameObject L;
    public GameObject D;
    public GameObject F;
    public GameObject H;

    [Header("Input Setting")]
    [Range(0, 6)]
    public int iterations = 4; //数太大Unity会炸
    public string input = "F";
    public string rule = "F+F+F+F";

    public float angle = 45;
    [Range(0.9f, 1.1f)]
    public float scalingFactor = 1;

    [Header("Length Setting")]
    [Range(-5f, 50f)]
    public float inputHeight = 1;
    [Range(-5f, 5f)]
    public float stepHeight = 1;
    [Range(-5f, 5f)]
    public float openScale = 1;//开合程度


    [Header("Random Setting")]
    public bool isRandom = false;
    public Vector2 randomRange = new Vector2(-45,45);

    [Header("Result")]
    public string result;

    [Header("Pos&Rot Correction")]
    public Vector3 correctRot;
    public Vector3 correctScale;

    //[Header("Debug")]
    //public bool debug = true;

    List<point> points = new List<point>();
    List<GameObject> branches = new List<GameObject>();
    private string output;

    void Start()
    {
        GenerateTree();
        RotationCorrection();
    }

    public void GenerateTree()
    {
        rules.Clear();
        points.Clear();
        foreach (GameObject obj in branches)
        {
            //Destroy(obj);
            DestroyImmediate(obj);
        }
        branches.Clear();

        // 自定义生成Rules，具体规则和示例可以参照用户指南→http://paulbourke.net/fractals/lsys/
        rules.Add('S', rule);

        // Apply rules for i interations
        output = input;
        for (int i = 0; i < iterations; i++)
        {
            output = applyRules(output);
        }
        result = output;
        determinePoints(output);
        CreateGos();

    }

    string applyRules(string p_input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in p_input)
        {
            if (rules.ContainsKey(c))
            {
                sb.Append(rules[c]);
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    
    struct point
    {
        public point(Vector3 rP, Vector3 rA, float rL, GameObject g) { Pos = rP; Angle = rA; BranchLength = rL; go = g; }
        public Vector3 Pos;
        public Vector3 Angle;
        public float BranchLength;
        public GameObject go;//prefab for current point
    }

    void determinePoints(string p_input)
    {
        Stack<point> returnValues = new Stack<point>();
        point lastPoint = new point(new Vector3(transform.position.x, transform.position.y + stepHeight, transform.position.z), transform.eulerAngles, inputHeight, S);//初始位置和父物体关联
        returnValues.Push(lastPoint);

        foreach (char c in p_input)
        {
            switch (c)
            {
                case 'S': //Stem
                    points.Add(lastPoint);

                    point newPoint = new point(lastPoint.Pos + new Vector3(0, lastPoint.BranchLength, 0), lastPoint.Angle, inputHeight, S);
                    newPoint.BranchLength = lastPoint.BranchLength * scalingFactor;
                    if (newPoint.BranchLength <= 0.0f) newPoint.BranchLength = 0.001f;

                    newPoint.Angle.y = lastPoint.Angle.y;

                    //add random
                    if (isRandom == true)
                    {
                        newPoint.Angle.y += UnityEngine.Random.Range(randomRange.x, randomRange.y);
                    }

                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(newPoint.Angle.x, 0, 0));
                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(0, newPoint.Angle.y, 0));
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);

                    points.Add(newPoint);
                    lastPoint = newPoint;
                    break;


                case 'P': //Petal
                    points.Add(lastPoint);

                    newPoint = new point(lastPoint.Pos + new Vector3(0, lastPoint.BranchLength, 0), lastPoint.Angle, inputHeight, P);
                    newPoint.BranchLength = lastPoint.BranchLength * scalingFactor;
                    if (newPoint.BranchLength <= 0.0f) newPoint.BranchLength = 0.001f;

                    newPoint.Angle.y = lastPoint.Angle.y;

                    //add random
                    if (isRandom == true)
                    {
                        newPoint.Angle.y += UnityEngine.Random.Range(randomRange.x, randomRange.y);
                    }

                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(newPoint.Angle.x, 0, 0));
                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(0, newPoint.Angle.y, 0));
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);

                    points.Add(newPoint);
                    lastPoint = newPoint;
                    break;

                case 'L': //Leaf
                    points.Add(lastPoint);

                    newPoint = new point(lastPoint.Pos + new Vector3(0, lastPoint.BranchLength, 0), lastPoint.Angle, inputHeight, L);
                    newPoint.BranchLength = lastPoint.BranchLength * scalingFactor;
                    if (newPoint.BranchLength <= 0.0f) newPoint.BranchLength = 0.001f;

                    newPoint.Angle.y = lastPoint.Angle.y;

                    //add random
                    if (isRandom == true)
                    {
                        newPoint.Angle.y += UnityEngine.Random.Range(randomRange.x, randomRange.y);
                    }

                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(newPoint.Angle.x, 0, 0));
                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(0, newPoint.Angle.y, 0));
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);

                    points.Add(newPoint);
                    lastPoint = newPoint;
                    break;

                case 'D': //Leaf
                    points.Add(lastPoint);

                    newPoint = new point(lastPoint.Pos + new Vector3(0, lastPoint.BranchLength, 0), lastPoint.Angle, inputHeight, D);
                    newPoint.BranchLength = lastPoint.BranchLength * scalingFactor;
                    if (newPoint.BranchLength <= 0.0f) newPoint.BranchLength = 0.001f;

                    newPoint.Angle.y = lastPoint.Angle.y;

                    //add random
                    if (isRandom == true)
                    {
                        newPoint.Angle.y += UnityEngine.Random.Range(randomRange.x, randomRange.y);
                    }

                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(newPoint.Angle.x, 0, 0));
                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(0, newPoint.Angle.y, 0));
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);

                    points.Add(newPoint);
                    lastPoint = newPoint;
                    break;

                case 'H': //Leaf
                    points.Add(lastPoint);

                    newPoint = new point(lastPoint.Pos + new Vector3(0, lastPoint.BranchLength, 0), lastPoint.Angle, inputHeight, H);
                    newPoint.BranchLength = lastPoint.BranchLength * scalingFactor;
                    if (newPoint.BranchLength <= 0.0f) newPoint.BranchLength = 0.001f;

                    newPoint.Angle.y = lastPoint.Angle.y;

                    //add random
                    if (isRandom == true)
                    {
                        newPoint.Angle.y += UnityEngine.Random.Range(randomRange.x, randomRange.y);
                    }

                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(newPoint.Angle.x, 0, 0));
                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(0, newPoint.Angle.y, 0));
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);

                    points.Add(newPoint);
                    lastPoint = newPoint;
                    break;

                case 'F': //Leaf
                    points.Add(lastPoint);

                    newPoint = new point(lastPoint.Pos + new Vector3(0, lastPoint.BranchLength, 0), lastPoint.Angle, inputHeight, F);
                    newPoint.BranchLength = lastPoint.BranchLength * scalingFactor;
                    if (newPoint.BranchLength <= 0.0f) newPoint.BranchLength = 0.001f;

                    newPoint.Angle.y = lastPoint.Angle.y;

                    //add random
                    if (isRandom == true)
                    {
                        newPoint.Angle.y += UnityEngine.Random.Range(randomRange.x, randomRange.y);
                    }

                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(newPoint.Angle.x, 0, 0));
                    newPoint.Pos = pivot(newPoint.Pos, lastPoint.Pos, new Vector3(0, newPoint.Angle.y, 0));
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);
                    //newPoint.Point = pivot(newPoint.Point, lastPoint.Point, Vector3.zero);

                    points.Add(newPoint);
                    lastPoint = newPoint;
                    break;


                case '+': // Rotate
                    lastPoint.Angle.x += angle;
                    break;
                case '[': // Save State
                    returnValues.Push(lastPoint);
                    break;
                case '-': // Rotate
                    lastPoint.Angle.x += -angle;
                    break;
                case ']': // Load Saved State
                    lastPoint = returnValues.Pop();
                    break;
                case '*': // Load Saved State
                    lastPoint.Angle.z += angle;
                    break;
                case '&': // Load Saved State
                    lastPoint.Angle.z -= angle;
                    break;
                case '/': // Load Saved State
                    lastPoint.Angle.y += angle;
                    break;
                case '?': // Load Saved State
                    lastPoint.Angle.y -= angle;
                    break;
            }
        }
    }

    void CreateGos()
    {
        for (int i = 0; i < points.Count; i += 2)
        {
            CreateGo(points[i], points[i + 1], 1f);
        }
    }

    //
    Vector3 pivot(Vector3 point1, Vector3 point2, Vector3 angles)
    {
        Vector3 dir = point1 - point2;
        dir = Quaternion.Euler(angles) * dir;
        point1 = dir + point2;
        return point1;
    }

    void CreateGo(point point1, point point2, float radius)
    {
        
        GameObject newGo = (GameObject)Instantiate(point2.go);
        newGo.SetActive(true);
        float length = Vector3.Distance(point2.Pos, point1.Pos);
        //radius = radius * length;
        Debug.Log(length);

        Vector3 scale = new Vector3(radius, openScale, radius);
        //newGo.transform.localScale = scale;

        newGo.transform.position = point1.Pos;
        newGo.transform.Rotate(point2.Angle);

        newGo.transform.parent = this.transform;

        branches.Add(newGo);
    }

    void Update()
    {
        //if (debug)
        //{
        //    for (int i = 0; i < points.Count; i += 2)
        //    {
        //        Debug.DrawLine(points[i].Pos, points[i + 1].Pos, Color.red);
        //    }
        //}
    }

    public void RotationCorrection()
    {
        transform.rotation =  Quaternion.Euler(transform.rotation.x + 10, transform.rotation.y + 90, transform.rotation.z + 90);
        transform.localScale = correctScale;
    }

}