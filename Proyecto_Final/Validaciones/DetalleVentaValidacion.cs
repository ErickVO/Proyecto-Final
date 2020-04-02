using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using Proyecto_Final.Entidades;
using Proyecto_Final.Contenedores;

namespace Proyecto_Final.Validaciones
{
    public class DetalleVentaValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                List<ListaVentas> detalle = (List<ListaVentas>)value;

                if (detalle.Count > 0)
                {
                    return ValidationResult.ValidResult;
                }
                return new ValidationResult(false, "Debe Agregar un campo al Detalle para Guardar");
            }
            return new ValidationResult(false, "Debe Agregar un campo al Detalle para Guardar");
        }
    }
}
