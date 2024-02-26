using UnityEditor;
using System.Diagnostics;
using System.IO;
using UnityEngine.Device;


namespace Gamebok.GeneralUtilities.Editor
{
    public static class OpenWithVSCode
    {
        [MenuItem("Assets/Gamebok/Open in VSCode", false, 0)]
        private static void OpenFileWithVSCode()
        {
            var selectedObject = Selection.activeObject;
            var assetPath = AssetDatabase.GetAssetPath(selectedObject.GetInstanceID());
            
            var combined = Path
                .Combine(Application.dataPath, assetPath)
                .Replace(@"\Assets", string.Empty);
            
#if UNITY_EDITOR_WIN
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c code {combined}",
                UseShellExecute = false,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                CreateNoWindow = true
            };
#elif UNITY_EDITOR_OSX
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "open",
                Arguments = "-a Visual\\ Studio\\ Code " + combined, // Use -a to specify the application
                UseShellExecute = false,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                CreateNoWindow = true
            };
#endif

            var process = new Process
            {
                StartInfo = processStartInfo
            };

            process.Start();
            process.WaitForExit();
        }
    }
}



