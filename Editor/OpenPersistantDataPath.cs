using UnityEditor;
using UnityEngine;

namespace Superplay.GeneralUtilities.Editor
{
    public static class OpenPersistentDataPath
    {
        [MenuItem("Superplay/Utility/Open Persistent Data Path", priority = 0)]
        public static void Perform()
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }
    }
}