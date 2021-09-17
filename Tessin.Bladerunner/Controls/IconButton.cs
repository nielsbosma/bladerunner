﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQPad;
using LINQPad.Controls;

// https://materialdesignicons.com/icon/svg

namespace Tessin.Bladerunner.Controls
{
    public class IconButton : Button
    {
        public IconButton(string icon, Action<LINQPad.Controls.Button> onClick = null, string tooltip = "", Color color = Color.Black) : base("", onClick)
        {
            this.AddClass($"icon-button {color.ToString().ToLower()}");
            this.HtmlElement.SetAttribute("title", tooltip);
            this.HtmlElement.InnerHtml = icon;
        }
    }
}
