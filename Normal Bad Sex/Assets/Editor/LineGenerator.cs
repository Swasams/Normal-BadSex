using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;



public static class LineGenerator
{
    private static string _tsvFile;
    private static string _lineFolder;
    private static string _audioClipsFolder;
    private static string _characterFolder;
    private static string _storyName;

    [MenuItem("Tools/Generate Lines")]
    public static void GenerateLines()
    {
        _storyName = EditorInputDialog.Show("Name of the Story", "", "");
        if (string.IsNullOrEmpty(_storyName))
        {
            Debug.LogWarning("Name cannot be empty");
            return;
        }

        _tsvFile = EditorUtility.OpenFilePanel("Please select story file", "", "tsv");
        if (string.IsNullOrEmpty(_tsvFile)) return;

        _lineFolder = EditorUtility.OpenFolderPanel("Please select the folder to store the Lines", "", "Lines");
        if (string.IsNullOrEmpty(_lineFolder)) return;

        _audioClipsFolder = EditorUtility.OpenFolderPanel("Please select the folder where the audio clips are stored",
            "", "Audio Clips");
        if (string.IsNullOrEmpty(_audioClipsFolder)) return;

        _characterFolder = EditorUtility.OpenFolderPanel("Please select the folder where the characters are stored", "", "Characters");
        if (string.IsNullOrEmpty(_characterFolder)) return;

        // string animationsFolder = EditorUtility.OpenFolderPanel("Please select the folder where the animations are stored", "","Animations");
        // if (string.IsNullOrEmpty(animationsFolder)) return;

        string[] allEntries = File.ReadAllLines(_tsvFile);
        int index = 0;

        List<Line> allLines = new List<Line>();

        foreach (var entry in allEntries)
        {
            // Skip first row, these are the titles
            if (index == 0)
            {
                index++;
                continue;
            }

            string[] splitData = entry.Split('\t');
            if (splitData.Length == 6)
            {
                Line processedLine = ProcessLine(splitData, index);
                allLines.Add(processedLine);
            }
            else
            {
                Debug.LogWarning($"Found an entry that doesn't match required amount of fields. Entry: {entry}");
            }
            index++;

        }

        // Check for existing story
        string storyPath = Path.GetDirectoryName(_tsvFile).Replace("\\", "/") + $"/{_storyName}.asset";
        string relativeStoryPath = storyPath[storyPath.IndexOf("Assets/", StringComparison.Ordinal)..];
        Story story;
        if (File.Exists(storyPath))
        {
            story = AssetDatabase.LoadAssetAtPath<Story>(relativeStoryPath);
        }
        else
        {
            story = ScriptableObject.CreateInstance<Story>();
        }

        story.SetLines(allLines);

        AssetDatabase.SaveAssets();
    }

    private static Line ProcessLine(string[] splitData, int index)
    {
        string linePath = _lineFolder + $"/{index:000}_{_storyName}.asset";
        string relativeLinePath = linePath[linePath.IndexOf("Assets/", StringComparison.Ordinal)..];

        Line line;
        bool createAsset = false;

        // Check for existing line
        if (File.Exists(linePath))
        {
            line = AssetDatabase.LoadAssetAtPath<Line>(relativeLinePath);
        }
        else
        {
            line = ScriptableObject.CreateInstance<Line>();
            createAsset = true;
        }

        // Check audio clip
        string absoluteSoundClipPath = $"{_audioClipsFolder}/{splitData[1]}.wav";
        string relativeSoundClipPath = absoluteSoundClipPath[absoluteSoundClipPath.IndexOf("Assets/", StringComparison.Ordinal)..];
        if (File.Exists(absoluteSoundClipPath))
        {
            line.audioFile =
                (AudioClip)AssetDatabase.LoadAssetAtPath(relativeSoundClipPath, typeof(AudioClip));
        }
        else
        {
            Debug.LogWarning($"Unable to find audio clip: {relativeSoundClipPath} for line number {index:000}");
            line.audioFile = null;
        }

        // Load text line
        try
        {
            line.ProcessPauses(splitData[0]);
        }
        catch (Exception e)
        {
            line.lineText = splitData[0];
        }



        // Line number
        line.lineNumber = index;



        // Load character
        // Check audio clip
        string absoluteCharacterPath = $"{_characterFolder}/{splitData[2]}.asset";
        string relativeCharacterPath = absoluteCharacterPath[absoluteCharacterPath.IndexOf("Assets/", StringComparison.Ordinal)..];
        if (File.Exists(absoluteCharacterPath))
        {
            line.speaker =
                (Character)AssetDatabase.LoadAssetAtPath(relativeCharacterPath, typeof(Character));
        }
        else
        {
            Debug.LogWarning($"Unable to find character: {relativeCharacterPath} for line number {index:000}");
            line.speaker = null;
        }

        // Load animations
        line.startAnimation = splitData[3];

        line.endAnimation = null;

        // Advance on end
        line.autoAdvanceOnEnd = false;

        if (createAsset)
        {
            AssetDatabase.CreateAsset(line, relativeLinePath);
        }

        return line;
    }
}