using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.IO;

public class Settings : MonoBehaviour
{
    public static int PickupShapeBonus;
    public static float PickupColorMult;
    public static float PickupShapeColorMult;
    public static int PickupShapeColorBonus;

    public TextAsset XMLDoc;

    void Awake()
    {
        using (TextReader reader = new StringReader(XMLDoc.text))
        {
            XDocument pickupSettings = XDocument.Load(reader);
            XElement root = pickupSettings.Element("Score");

            PickupShapeBonus = int.Parse(root.Element("SameShapeBonus").Value);
            PickupShapeColorBonus = int.Parse(root.Element("SameShapeColorBonus").Value);
            PickupColorMult = float.Parse(root.Element("SameColorMult").Value);
            PickupShapeColorMult = float.Parse(root.Element("SameShapeColorMult").Value);
        }
    }
}