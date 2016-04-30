using UnityEngine;
using System.Collections;

public class Achievment : MonoBehaviour {
	public GameObject Logo;
	public UnityEngine.UI.Text Name,Description;
	public UnityEngine.UI.Image Background;
	public GameObject TextContainer;
	public GameObject theCam;
	//public Animation flashAnimation;
	public Material mat;
	Color c;
	// Use this for initialization
	void Start () {
		c = new Color (1f,1f,1f,0f);
		//Invoke("Show",1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	[ContextMenu ("Show")]
	void Show(){
		StartCoroutine("ShowAchievment");

		Debug.Log("Show");

	}
	IEnumerator ShowAchievment(){
		Vector3 to = new Vector3(theCam.transform.position.x - Background.transform.position.x,
			0f,
			0f
		);
		Debug.Log(to);
		int count = 0;
		while(mat.color.a < 1f ){
			count++;
			Background.transform.position += to * 0.1f;
			mat.color += new Color(0f,0f,0f,0.1f);
			yield return null;
		}
		Background.transform.position -= to * 0.1f;
		Logo.SetActive(true);
		TextContainer.SetActive(true);

		while(mat.color.a > 0f ){
			mat.color -= new Color(0f,0f,0f,0.02f);
			yield return null;
		}
		yield return null;
	}
}
