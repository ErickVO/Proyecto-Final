using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace Proyecto_Final.Validaciones
{
    public class FechaVencimientoValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                DateTime fecha = new DateTime();
                DateTime.TryParse(value.ToString(), out fecha);

                if (fecha > DateTime.Now)
                    return new ValidationResult(false, "Debes poner una Fecha valida");

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner una Fecha");
        }
    }
}
