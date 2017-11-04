using UnityEngine;
using UnityEditor;

using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

public class PyTerminalWindow : EditorWindow {

    const string PROJECT_NAME = "PyTerminal";

	public static string PythonScriptPath;
	public const string IronPythonTemplateFile = "__template__.py";

	static string codeTemplate = "";

	static ScriptEngine scriptEngine;
	static ScriptScope scriptScope;

	string pythonCode = "";
	string history = "";
    string pythonFileName = "";

	bool insertIndent = false;
	int id;

	bool IsPromptFocused {
		get {
			return GUI.GetNameOfFocusedControl() == PROJECT_NAME;
		}
	}

	void OnEnable() {
		if (string.IsNullOrEmpty(PythonScriptPath))
			PythonScriptPath = Application.dataPath + @"/PythonPrompt/PythonScripts/";
	}

	[MenuItem("Tools/Python Prompt")]
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
        using (var scroll = new GUILayout.ScrollViewScope(scrollPosition)) {
			scrollPosition = scroll.scrollPosition;
			GUILayout.Label(history);
		}

		GUI.backgroundColor = Color.white;

		var style = new GUIStyle(GUI.skin.textArea);
		style.fontSize = 11;
		style.wordWrap = false;

		GUI.SetNextControlName(PROJECT_NAME);

        // Text Area
		pythonCode = GUILayout.TextArea(pythonCode, style, GUILayout.Height(position.height / 2));

		if (insertIndent) {
			insertIndent = false;

			var editor = (TextEditor) GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
			editor.MoveTextEnd();
		}

		if (GetKeyDown(KeyCode.Tab)) {
			pythonCode += "    ";
			insertIndent = true;
		}

		GUI.backgroundColor = GUI.contentColor;

        // Run Button
		if (GUILayout.Button("Run")) {
			ExecutePythonCode(pythonCode);
		}

        // Run external Python code
        pythonFileName = GUILayout.TextField(pythonFileName);
        if (GUILayout.Button("Run File")) {
            ExecutePythonFile(pythonFileName);
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
