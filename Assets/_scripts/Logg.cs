using UnityEngine;
using System.Collections;

public class Logg : MonoBehaviour
{
	public static void LogListDelim (string delimiter, params object[] args){
		string result = "";
		foreach (object arg in args) {
			result += delimiter + arg;
		}
		Debug.Log(result.Substring (1));
	}

	public static void LogList (params object[] args){
		string result = "";
		foreach (object arg in args) {
			result += ", " + arg;
		}
		Debug.Log(result.Substring (1));
	}

	public static string ListString (params object[] args){
		string result = "";
		foreach (object arg in args) {
			result += ", " + arg;
		}
		return result.Substring (1);
	}
}

