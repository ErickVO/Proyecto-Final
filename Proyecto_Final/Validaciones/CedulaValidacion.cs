using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Proyecto_Final.Validaciones
{
    public class CedulaValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value as string;

            if (cadena != null)
            {
                String expresion;
                expresion = @"^\d{3}[- ]?\d{7}[- ]?\d{1}$";
                if (Regex.IsMatch(cadena, expresion))
                {
                    if (Regex.Replace(cadena, expresion, String.Empty).Length == 0)
                    {
                        return ValidationResult.ValidResult;
                    }
                    else
                    {
                        return new ValidationResult(false, "Cedula no valida");
                    }
                }
                else
                    return new ValidationResult(false, "Cedula no valido");
            }
            return new ValidationResult(false, "Debes poner una Cedula");
        }
    }
}
