using UnityEngine;
using UnityEditor;

using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

public class PyTerminalWindow : EditorWindow {

    const string PROJECT_NAME = "PyTerminal";

	public static string PythonScriptPath;
	public const string IronPythonTemplateFile = "__template__.py";

	static string codeTemplate = "";

	ScriptEngine scriptEngine;
	ScriptScope scriptScope;

	string pythonCode = "";
	string history = "";
    string pythonFileName = "";

	void OnEnable() {
		if (string.IsNullOrEmpty(PythonScriptPath)) {
            PythonScriptPath = Application.dataPath + @"/PythonPrompt/PythonScripts/";
        }
    }

	[MenuItem("Tools/" + PROJECT_NAME)]
	public static void RunPython() {
		var window = GetWindow<PyTerminalWindow>();
		window.Initialize();
	}

	void Initialize() {
        titleContent = new GUIContent(PROJECT_NAME);

		using (var reader = new System.IO.StreamReader(PythonScriptPath + IronPythonTemplateFile)) {
			codeTemplate = reader.ReadToEnd();
		}
		pythonCode = history = "";

		scriptEngine = Python.CreateEngine();
		scriptScope = scriptEngine.CreateScope();
	}

	Vector2 scrollPosition;
	void OnGUI() {
        // Run external Python code
        GUI.SetNextControlName("File Name");
        pythonFileName = EditorGUILayout.TextField(pythonFileName);
        if (GUILayout.Button("Run File")) {
            ExecutePythonFile(pythonFileName);
        }

        // hiistory panel
        using (var scroll = new EditorGUILayout.ScrollViewScope(scrollPosition)) {
			scrollPosition = scroll.scrollPosition;
			GUILayout.Label(history);
		}

		GUI.backgroundColor = Color.white;

		var style = new GUIStyle(GUI.skin.textArea);
		style.fontSize = 11;
		style.wordWrap = false;

        // Text Area
        GUI.SetNextControlName("Code Editor");
        pythonCode = GUILayout.TextArea(pythonCode, style, GUILayout.Height(position.height / 2));

        if (GetKeyDown(KeyCode.Tab)) {
            //EditorGUI.FocusTextInControl("File Name");
            Event.current.type = EventType.Ignore;

            // expand tab input to spaces
            pythonCode += "    ";
            var editor = (TextEditor) GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
            editor.cursorIndex += 4;
        }

        GUI.backgroundColor = GUI.contentColor;

        // Run Button
		if (GUILayout.Button("Run")) {
			ExecutePythonCode(pythonCode);
		}
	}

	bool GetKeyDown(KeyCode keyCode) {
		if (Event.current.type == EventType.KeyDown) {
			if (Event.current.keyCode == keyCode) {
				return true;
			}
		}
		return false;
	}

	void ExecutePythonCode(string code) {
		var scriptSource = scriptEngine.CreateScriptSourceFromString(string.Format(codeTemplate, code));
		scriptSource.Execute(scriptScope);
		history += code + "\n";
		pythonCode = "";
		GUIUtility.keyboardControl = 0;
	}

    void ExecutePythonFile(string fileName) {
        using (var fileReader = new System.IO.StreamReader(PythonScriptPath + fileName)) {
            var code = fileReader.ReadToEnd();
            ExecutePythonCode(code);
        }
    }
}
