using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace Proyecto_Final.Validaciones
{
    public class CantidadValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                decimal cantidad = 0;
                try
                {
                    cantidad = Convert.ToDecimal(value);
                }
                catch
                {
                    return new ValidationResult(false, "La cantidad debe ser un numero");
                }

                if (cantidad >= 0.1m)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "La cantidad debe mayor o igual a 0.1");

            }
            return new ValidationResult(false, "Debes poner una cantidad");
        }
    }
}
