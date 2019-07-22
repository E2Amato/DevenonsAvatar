﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CanyonProximityDataReplay : MonoBehaviour {

    public SensorGeneric<float> canyonProximity = new SensorGeneric<float>("canyonProximity");

    //static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string SPLIT_RE = ",";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    //static char[] TRIM_CHARS = { '\"' };

    void Awake()
    {
        string path = Application.dataPath + "/StreamingAssets/dump.csv";
        string data = System.IO.File.ReadAllText(path);

        var lines = Regex.Split(data, LINE_SPLIT_RE);

        for (int i = 0; i < lines.Length - 1; i++)
        {
            {
                var valuesTab = Regex.Split(lines[i], SPLIT_RE);

                if (valuesTab[0] == "CanyonProximity")
                {
                    canyonProximity.maxDataIndex = valuesTab.Length - 1;

                    for (var y = 1; y < valuesTab.Length; y++)
                        canyonProximity.AddRecordedValue(float.Parse(valuesTab[y].ToString()));
                }
            }
        }
    }
}
