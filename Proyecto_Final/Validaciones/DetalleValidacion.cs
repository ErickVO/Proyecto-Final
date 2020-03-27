using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Proyecto_Final.Validaciones
{
    class DetalleValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Debe Agregar un campo al Detalle para Guardar");
        }
    }
}
