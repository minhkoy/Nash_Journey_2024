﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_MVC.Models.Helpers
{
    /// <summary>
    /// Constant extension
    /// </summary>
    public static class ConstantExtensions
    {
        public class Genders
        {
            public const string Male = "Male";
            public const string Female = "Female";
        }

        public class Comparer
        {
            public const string GreaterThan = ">";
            public const string LessThan = "<";
            public const string Equal = "=";
        }
    }
}