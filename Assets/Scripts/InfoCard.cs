using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class InfoCard
{

    public event Action Cambio;

    public string elixir;

    public string image;

    public InfoCard(string elixir, string image)
    {

        this.elixir = elixir;
        this.image = image;
    }

    public void ActivateChange()
    {
        Cambio();
    }


}
