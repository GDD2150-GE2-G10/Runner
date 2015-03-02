using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.IO;

public class Settings : MonoBehaviour
{
    //Score pickup settings
    public static int pickupShapeBonus { get; protected set; }
    public static float pickupColorMult { get; protected set; }
    public static float pickupColorMultDur { get; protected set; }
    public static int pickupShapeColorBonus { get; protected set; }
    public static float pickupShapeColorMult { get; protected set; }
    public static float pickupShapeColorMultDur { get; protected set; }

    public TextAsset XMLDoc;

    void Awake()
    {
        using (TextReader reader = new StringReader(XMLDoc.text))
        {
            XDocument pickupSettings = XDocument.Load(reader);

            //read pickup settings
            XElement root = pickupSettings.Element("Pickups").Element("Score");

            //read score settings
            pickupShapeBonus = int.Parse(root.Element("SameShapeBonus").Value);
            pickupColorMult = float.Parse(root.Element("SameColorMult").Value);
            pickupColorMultDur = float.Parse(root.Element("SameColorMultDur").Value);
            pickupShapeColorBonus = int.Parse(root.Element("SameShapeColorBonus").Value);
            pickupShapeColorMult = float.Parse(root.Element("SameShapeColorMult").Value);
            pickupShapeColorMultDur = float.Parse(root.Element("SameShapeColorMultDur").Value);
        }
    }
}