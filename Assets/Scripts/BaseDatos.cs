using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using static JSONHelper;
using static Unity.VisualScripting.LudiqRootObjectEditor;

public class BaseDatos
{
    public static List<InfoCard> getData()
    {
        List<InfoCard> datos = new List<InfoCard>();

        string path = Path.Combine(Application.persistentDataPath, "desk_info");
        string individuosInfo = File.ReadAllText(path);

        datos = JSONHelperInfoCard.FromJSON<InfoCard>(individuosInfo);

        datos.ForEach(elem => {

            Debug.Log(elem.elixir + " " + elem.image);

        });



        return datos;

    }



}
