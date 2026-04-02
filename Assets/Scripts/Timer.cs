using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public static class Timer
{
    private static readonly Stopwatch stopwatch = new();
    private static readonly List<long> steps = new(); 

    public static bool IsRunning
    {
        get => stopwatch.IsRunning;
    }

    public static double ElapsedSeconds
    {
        get => stopwatch.ElapsedMilliseconds * 0.001f;
    }

    public static int StepsCount
    {
        get => steps.Count;
    }

    public static double GetStepElapsedSeconds(int index)
    {
        return steps[index] * 0.001f;
    }

    /// <summary>
    /// Reset the timer and remove any steps.
    /// </summary>
    public static void Reset()
    {
        stopwatch.Reset();
        steps.Clear();
    }

    public static void Start()
    {
        stopwatch.Start();
    }

    public static void Stop()
    {
        stopwatch.Stop();
    }

    public static void Step()
    {
        steps.Add(stopwatch.ElapsedMilliseconds);
    }

    public static void Save()
    {
        // TODO : save our time steps (line 7 of this script) inside a file.
        string path = Application.dataPath + "/score.txt";

        long currentTime = stopwatch.ElapsedMilliseconds;

        if(File.Exists(path))
        {
            string encoded = File.ReadAllText(path);
            string decoded = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(encoded));
            string[] lines = decoded.Split('\n');

            if (lines.Length > 0 && long.TryParse(lines[lines.Length-1], out long bestTime))
            {
                if (currentTime < bestTime)
                {
                    UnityEngine.Debug.Log("New record! " + currentTime + "ms");
                }
                else
                {
                    UnityEngine.Debug.Log("Record not beaten. Current time: " + currentTime + "ms, Best time: " + bestTime + "ms");
                    return;
                }
            }
        }

        List<string> linesToSave = new List<string>();
        foreach (long step in steps)
        {
            linesToSave.Add(step.ToString());
        }

        string joined = string.Join("\n", linesToSave);
        string encodedData = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(joined));

        File.WriteAllText(path, encodedData);
    }

    public static void Load()
    {
        // TODO : load our time steps from a file (if we have any)
        // and store them inside our steps variable (line 7 of this script)
        // to show them to the player before starting a race.

        string path = Application.dataPath + "/score.txt";

        if (!File.Exists(path))
        {
            UnityEngine.Debug.Log("pas de fichier score");
            return;
        }

        string encoded = File.ReadAllText(path);
        string decoded = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(encoded));
        string[] lines = decoded.Split('\n');

        steps.Clear();

        foreach (string line in lines)
        {
            if (long.TryParse(line, out long value))
            {
                steps.Add(value);
            }
        }

        UnityEngine.Debug.Log("Loaded score from " + path);
    }
}
