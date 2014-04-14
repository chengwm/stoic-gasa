using UnityEngine;
using System.Collections;

public class PointInstantiator_MainHall : MonoBehaviour
{

	private const string spawnpointString = "spawnpoint";
	private const string coverpointString = "coverpoint";
	private const string waypointString = "waypoint";
	private Vector3 temp;
	private GameObject point;

	public GameObject m_PrefabPoint;

	// Use this for initialization
	void Start ()
	{
		// instantiate spawnpoints A(0) to L (12)
		for(int i = 0; i < 13; i++)
		{
			switch (i)
			{
				case 0:
					temp = new Vector3(88f, 2f, 294f);
					break;
				case 1:
					temp = new Vector3(-90f, 2f, 294f);
					break;
				case 2:
					temp = new Vector3(65.76173f, -2f, 114.4437f);
					break;
				case 3:
					temp = new Vector3(-69.85675f, -2f, 108.4878f);
					break;
				case 4:
					temp = new Vector3(59.96916f, -2f, 36.0363f);
					break;
				case 5:
					temp = new Vector3(-0.5277253f, 0.0862627f, 57.57142f);
					break;
				case 6:
					temp = new Vector3(67.47065f, 18.68524f, 103.9517f);
					break;
				case 7:
					temp = new Vector3(72.06992f, -2f, 202.2107f);
					break;	
				case 8:
					temp = new Vector3(-65.20425f, -2f, 173.2868f);
					break;
				case 9:
					temp = new Vector3(72.11064f, 18.68524f, 39.25517f);
					break;
				case 10:
					temp = new Vector3(-61.06641f, 18.68524f, 32.09503f);
					break;
				case 11:
					temp = new Vector3(-31.89889f, 27.05476f, 46.12529f);
					break;
				case 12:
					temp = new Vector3(16.68564f, 18.68524f, 46.12529f);
					break;
				default:
						break;
			}
			MakePoint(temp, i, spawnpointString);
		}

		//instantiate coverpoints 0 to 31
		for(int i = 0; i < 31; i++)
		{
			switch (i)
			{
				case 0:
					temp = new Vector3(-64.94016f, -2f, 247.1781f);
					break;
				case 1:
					temp = new Vector3(-32.70973f, -2f, 217.7529f);
					break;
				case 2:
					temp = new Vector3(42.69889f, -2f, 219.2763f);
					break;
				case 3:
					temp = new Vector3(21.39306f, -2f, 177.931f);
					break;
				case 4:
					temp = new Vector3(-7.620615f, -2f, 171.9453f);
					break;
				case 5:
					temp = new Vector3(-35.86661f, 20f, 155.8154f);
					break;
				case 6:
					temp = new Vector3(-54.37291f, 20f, 155.8154f);
					break;
				case 7:
					temp = new Vector3(-63.63501f, 20f, 153.6944f);
					break;
				case 8:
					temp = new Vector3(39.61717f, 20f, 148.3898f);
					break;
				case 9:
					temp = new Vector3(50.59138f, 20f, 154.4124f);
					break;
				case 10:
					temp = new Vector3(73.38069f, 20f, 154.4124f);
					break;
				case 11:
					temp = new Vector3(-16.73845f, -2f, 164.4281f);
					break;
				case 12:
					temp = new Vector3(-22.76004f, -2.737274f, 94.59435f);
					break;
				case 13:
					temp = new Vector3(45.5601f, 18.68524f, 145.7996f);
					break;
				case 14:
					temp = new Vector3(55.04093f, 20f, 55.12134f);
					break;
				case 15:
					temp = new Vector3(12.68689f, 20f, 55.12134f);
					break;
				case 16:
					temp = new Vector3(-23.01767f, 20f, 56.86711f);
					break;
				case 17:
					temp = new Vector3(56.55583f, 18f, 142.9348f);
					break;
				case 18:
					temp = new Vector3(61.75164f, 18f, 126.372f);
					break;
				case 19:
					temp = new Vector3(61.61436f, 18f, 106.1892f);
					break;
				case 20:
					temp = new Vector3(15.7077f, -2f, 170.9986f);
					break;
				case 21:
					temp = new Vector3(-21.09468f, -2f, 167.285f);
					break;
				case 22:
					temp = new Vector3(57.58482f, -2f, 100.6965f);
					break;
				case 23:
					temp = new Vector3(-66.26376f, -2f, 227.1879f);
					break;
				case 24:
					temp = new Vector3(24.16898f, -2f, 261.1624f);
					break;
				case 25:
					temp = new Vector3(52.83988f, -2f, 261.1624f);
					break;
				case 26:
					temp = new Vector3(-40.35526f, -2f, 262.4305f);
					break;
				case 27:
					temp = new Vector3(-64.05747f, -2f, 93.90499f);
					break;
				case 28:
					temp = new Vector3(-67.56793f, 20f, 76.23341f);
					break;
				case 29:
					temp = new Vector3(-68.04681f, 20f, 131.9254f);
					break;
				case 30:
					temp = new Vector3(8.5842f, -2f, 116.9141f);
					break;
				default:
						break;
			}
			MakePoint(temp, i, coverpointString);
		}

		for(int i = 0; i < 21; i++)
		{
			switch (i)
			{
				case 0:
					temp = new Vector3(-68.0619f, 2f, 288.3602f);
					break;
				case 1:
					temp = new Vector3(-73.51494f, -2f, 211.5412f);
					break;
				case 2:
					temp = new Vector3(65.84885f, 2f, 288.3602f);
					break;
				case 3:
					temp = new Vector3(70.65495f, -2f, 211.5412f);
					break;
				case 4:
					temp = new Vector3(67.47065f, 18.68524f, 150.5515f);
					break;
				case 5:
					temp = new Vector3(-63.89826f, 18.68524f, 146.776f);
					break;
				case 6:
					temp = new Vector3(-0.5277253f, -2f, 106.2173f);
					break;
				case 7:
					temp = new Vector3(-31.89889f, 49.94708f, 38.21809f);
					break;
				case 8:
					temp = new Vector3(-14.94937f, 49.94708f, 175.8f);
					break;
				case 9:
					temp = new Vector3(-74.10576f, -2f, 93.08757f);
					break;
				case 10:
					temp = new Vector3(65.84885f, 50f, 288.3602f);
					break;
				case 11:
					temp = new Vector3(30.91293f, 50f, 103.5328f);
					break;
				case 12:
					temp = new Vector3(-67.75548f, 50f, 288.3602f);
					break;
				case 13:
					temp = new Vector3(24.35672f, 48f, 203.7957f);
					break;
				case 14:
					temp = new Vector3(50.80825f, 2f, 288.3602f);
					break;
				case 15:
					temp = new Vector3(-3.513237f, 2f, 294f);
					break;
				case 16:
					temp = new Vector3(9.851121f, -2f, 165.5604f);
					break;
				case 17:
					temp = new Vector3(69.16316f, -2f, 86.03095f);
					break;
				case 18:
					temp = new Vector3(-5.746445f, -2f, 86.03095f);
					break;
				case 19:
					temp = new Vector3(-71.91593f, 18.68524f, 41.35037f);
					break;
				case 20:
					temp = new Vector3(65.84885f, 2f, 267.1868f);
					break;
				default:
					break;
			}
			MakePoint(temp, i, waypointString);
		}
	}
	/*
	// Update is called once per frame
	void Update ()
	{

	}
	*/

	void MakePoint(Vector3 position, int i, string pointString)
	{
		point = Instantiate(m_PrefabPoint, position, Quaternion.identity) as GameObject;
		point.name = string.Concat(pointString, i.ToString());
	}
}

