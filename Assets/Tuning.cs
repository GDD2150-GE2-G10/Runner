using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.IO;

public class Tuning : MonoBehaviour
{
    //pickup scoring settings
    public static int PICKUP_SHAPE_BONUS { get; protected set; }
    public static float PICKUP_COLOR_MULT { get; protected set; }
    public static float PICKUP_COLOR_MULT_DUR { get; protected set; }
    public static int PICKUP_SHAPE_COLOR_BONUS { get; protected set; }
    public static float PICKUP_SHAPE_COLOR_MULT { get; protected set; }
	public static float PICKUP_SHAPE_COLOR_MULT_DUR { get; protected set; }

	//pickup spawning settings
	public static int PICKUP_SPAWN_CHANCE { get; protected set; }

	//player settings
	public static float PLAYER_JUMP_FORCE { get; protected set; }
	public static float PLAYER_MOVE_VELOCITY { get; protected set; }

	//barrier settings
	public static float BARRIER_VELOCITY { get; protected set; }
	public static float BARRIER_SPAWN_DELAY { get; protected set; }

    public TextAsset XMLDoc;

    void Awake()
    {
        using (TextReader reader = new StringReader(XMLDoc.text))
        {
            XDocument pickupSettings = XDocument.Load(reader);
			XElement docHead = pickupSettings.Element("Tuning");

            //read pickup settings
			XElement root = docHead.Element("Pickups");

				//read score settings
				root = root.Element("Score");
	            PICKUP_SHAPE_BONUS = int.Parse(root.Element("SameShapeBonus").Value);
	            PICKUP_COLOR_MULT = float.Parse(root.Element("SameColorMult").Value);
	            PICKUP_COLOR_MULT_DUR = float.Parse(root.Element("SameColorMultDur").Value);
	            PICKUP_SHAPE_COLOR_BONUS = int.Parse(root.Element("SameShapeColorBonus").Value);
	            PICKUP_SHAPE_COLOR_MULT = float.Parse(root.Element("SameShapeColorMult").Value);
				PICKUP_SHAPE_COLOR_MULT_DUR = float.Parse(root.Element("SameShapeColorMultDur").Value);

				//read spawn settings
				root = docHead.Element("Pickups").Element("Spawning");
				PICKUP_SPAWN_CHANCE = Mathf.Clamp(int.Parse(root.Element("SpawnChance").Value), 0, 100);
			
			//read player settings
			root = docHead.Element("Player");
			PLAYER_JUMP_FORCE = float.Parse(root.Element("JumpForce").Value);
			PLAYER_MOVE_VELOCITY = float.Parse(root.Element("MoveSpeed").Value);
			
			//read barrier settings
			root = docHead.Element("Barrier");
			BARRIER_VELOCITY = float.Parse(root.Element("MoveSpeed").Value);
			BARRIER_SPAWN_DELAY = float.Parse(root.Element("SpawnDelay").Value);
        }
    }
}