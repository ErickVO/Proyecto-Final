using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace Proyecto_Final.Validaciones
{
    public class NombreValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value as string;
            if (!string.IsNullOrWhiteSpace(cadena))
            {
                if (cadena.Length <= 0)
                    return new ValidationResult(false, "Debes poner un Nombre");


                foreach (var caracter in cadena)
                {
                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                        return new ValidationResult(false, "El nombre solo puede tener letras");
                }

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner un Nombre");
        }
    }
}
