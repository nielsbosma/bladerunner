﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQPad;
using LINQPad.Controls;

// https://materialdesignicons.com/icon/svg

namespace Tessin.Bladerunner.Controls
{
    public class IconPlaceholder : Div
    {
        public IconPlaceholder()
        {
            this.Styles["width"] = "24px";
            this.Styles["height"] = "24px";
        }
    }

    public class Icon : Div
    {
        public static Icon Empty()
        {
            return new Icon("");
        }

        public Icon(string icon, string tooltip = "", Theme theme = Theme.Secondary) : base()
        {
            this.HtmlElement.SetAttribute("title", tooltip);
            this.HtmlElement.SetAttribute("class", $"icon icon-theme-{theme.ToString().ToLower()}");
            this.HtmlElement.InnerHtml = icon;
        }
    }
}