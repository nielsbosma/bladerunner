﻿using System;
using System.Reflection;

using LINQPad.Controls;
using Tessin.Bladerunner.Controls;

namespace Tessin.Bladerunner.Editors
{
    public class LinkEditor<T> : IFieldEditor<T>
    {

        private Action<T> _onClick;

        private readonly Func<T, string> _fetchUrl;

        public LinkEditor(Action<T> onClick)
        {
            _onClick = onClick;
        }

        public LinkEditor(Func<T, string> fetchUrl)
        {
            _fetchUrl = fetchUrl;
        }

        public LinkEditor()
        {
        }

        public object Render(T obj, Field<T> fieldInfo, Action preview)
        {
            var fieldLabel = new FieldLabel(fieldInfo.Label);

            var label = Convert.ToString(fieldInfo.GetValue(obj));

            Control link;

            if (_fetchUrl != null)
            {
                var url = _fetchUrl(obj);
                link = new Hyperlink(label, url);
            }
            else if(_onClick != null)
            {
                link = new Hyperlink(label, (_) => _onClick(obj));
            }
            else
            {
                link = new Hyperlink(label, label);
            }

            link.HtmlElement.SetAttribute("class", "entity-editor-link");

            return LINQPad.Util.VerticalRun(
                fieldLabel,
                link
            );
        }

        public void Save(T obj, Field<T> fieldInfo)
        {
            //ignore
        }

        public bool Validate(T obj, Field<T> fieldInfo)
        {
            return true;
        }
    }
}