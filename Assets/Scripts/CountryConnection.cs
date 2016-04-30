using UnityEngine;
using System.Collections;

public enum Way{Land, Air, Water}
public class CountryConnection {
	public Country ConnectedTo;
	public Way way;

}
