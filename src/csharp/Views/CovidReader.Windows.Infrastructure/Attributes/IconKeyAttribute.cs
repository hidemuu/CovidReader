﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Windows.Infrastructure.Attributes
{
    [System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class IconKeyAttribute : Attribute
    {
        public IconKeyAttribute(string key)
        {
            Key = key;
        }

        /// <summary>
        /// 表示名称
        /// </summary>
        public string Key { get; }
    }
}
