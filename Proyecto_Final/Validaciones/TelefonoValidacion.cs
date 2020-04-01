using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Proyecto_Final.Validaciones
{
    public class TelefonoValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value as string;

            if (cadena != null)
            {
                String expresion;
                expresion = @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$";
                if (Regex.IsMatch(cadena, expresion))
                {
                    if (Regex.Replace(cadena, expresion, String.Empty).Length == 0)
                    {
                        return ValidationResult.ValidResult;
                    }
                    else
                    {
                        return new ValidationResult(false, Message);
                    }
                }
                else
                    return new ValidationResult(false, Message);
            }
            return new ValidationResult(false, Message);
        }

        public String Message { get; set; }
    }
}
