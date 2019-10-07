using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Tab To: provides methods for tabbing to editor windows //
public static class TabTo
{
	private static void window<SearchableEditorWindowT>() where SearchableEditorWindowT : SearchableEditorWindow
		=> EditorWindow.FocusWindowIfItsOpen(typeof(SearchableEditorWindowT));

	public static void scene()
		=> window<SceneView>();
	
	public static void game()
		=> EditorApplication.ExecuteMenuItem("Window/Game");
}