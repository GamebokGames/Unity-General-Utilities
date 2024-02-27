using UnityEditor;
using UnityEngine;

namespace Gamebok.GeneralUtilities.Editor
{
    public static class OpenPersistentDataPath
    {
        [MenuItem("Gamebok/Open/Persistent Data Path", priority = 0)]
        public static void Perform()
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }
    }
}