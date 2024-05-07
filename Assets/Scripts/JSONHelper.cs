using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JSONHelper : MonoBehaviour
{
    public class JSONHelperInfoCard
    {

        [Serializable]
        private class ListaCard<InfoCard>
        {
            public List<InfoCard> InfoCards;
        }

        public static List<InfoCard> FromJSON<InfoCard>(string json)
        {
            ListaCard<InfoCard> listaInfoCard = JsonUtility.FromJson<ListaCard<InfoCard>>(json);

            return listaInfoCard.InfoCards;
        }

        public static string ToJson<InfoCard>(List<InfoCard> lista)
        {
            ListaCard<InfoCard> listaCard = new ListaCard<InfoCard>();
            listaCard.InfoCards = lista;

            return JsonUtility.ToJson(listaCard);
        }

        public static string ToJson<InfoCard>(List<InfoCard> lista, bool prettyPrint)
        {
            ListaCard<InfoCard> listaCard = new ListaCard<InfoCard>();
            listaCard.InfoCards = lista;

            return JsonUtility.ToJson(listaCard, prettyPrint);

        }



    }
}
