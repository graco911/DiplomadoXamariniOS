using System;
using System.ComponentModel;

namespace PatronMVC
{
    public enum Status
    {
        [DescriptionAttribute("Llamando al WebAPI.")] CallingWebAPI = 1,
        [DescriptionAttribute("Procesando la respuesta de el WebAPI.")] VerifyingResult = 2,
        [DescriptionAttribute("El Producto fue encontrado.")] ProductFound = 3,
        [DescriptionAttribute("El Producto no fue encontrado.")] ProductNotFound = 4
    }
}
