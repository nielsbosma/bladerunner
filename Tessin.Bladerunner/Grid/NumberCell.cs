﻿using System;
using System.Collections.Generic;
using System.Text;
using LINQPad.Controls;

namespace Tessin.Bladerunner.Grid
{
    public class NumberCell<T> : ICellRenderer<T>
    {
        private readonly string _format;

        public NumberCell(string format)
        {
            _format = format;
        }

        public Control Render(object value, GridColumn<T> column)
        {
            if (value == null) return new Literal("-");

            var _value = Convert.ToDouble(value);

            if(_value == 0) return new Literal("-");

            return new Literal(_value.ToString(_format));
        }
    }
}
