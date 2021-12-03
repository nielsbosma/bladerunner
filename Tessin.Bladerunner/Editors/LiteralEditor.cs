﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using LINQPad;
using LINQPad.Controls;
using Tessin.Bladerunner.Controls;

namespace Tessin.Bladerunner.Editors
{
    public class LiteralEditor<T> : IFieldEditor<T>
    {
        private Field _field;

        private DumpContainer _dumpContainer = new DumpContainer();
        
        private IContentFormatter _contentFormatter = new DefaultContentFormatter();

        public void Update(object value)
        {
            _dumpContainer.Content = _contentFormatter.Format(value, emptyContent: "-");
        }

        public object Render(T obj, EditorField<T> editorFieldInfo, Action preview)
        {
            _dumpContainer.Content = _contentFormatter.Format(editorFieldInfo.GetValue(obj), emptyContent:"-");
            return _field = new Field(editorFieldInfo.Label, _dumpContainer, editorFieldInfo.Description, editorFieldInfo.Helper);
        }

        public void Save(T obj, EditorField<T> editorFieldInfo)
        {
            //ignore
        }

        public bool Validate(T obj, EditorField<T> instruction)
        {
            return true;
        }

        public void SetVisibility(bool value)
        {
            _field.SetVisibility(value);
        }
    }
}
