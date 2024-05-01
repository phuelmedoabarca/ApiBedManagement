using Domain.Excepcions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class DocumentoIdentidad
    {
        public DocumentoIdentidad() { }
        public string Documento { get; private set; }
        public DocumentoIdentidad(string rut)
        {
            ValidarRut(rut);
            if (string.IsNullOrEmpty(rut))
            {
                throw new BadRequestException("Debe ingresar un Rut.");
            }
            if (!ValidarRut(rut))
            {
                throw new BadRequestException("Debe ingresar un Rut valido.");
            }
            Documento = rut;
        }
        private bool ValidarRut(string rut)
        {
            try
            {
                rut = rut.Replace(".", "").ToUpper();
                var expresion = new Regex("^([0-9]+-[0-9K])$");
                var dv = rut.Substring(rut.Length - 1, 1);
                if (!expresion.IsMatch(rut)) return false;
                char[] charCorte = { '-' };
                var rutTemp = rut.Split(charCorte);
                return dv == Digit(int.Parse(rutTemp[0]));
            }
            catch (Exception)
            {

                return false;
            }
        }
        private static string Digit(int rut)
        {
            var suma = 0;
            var multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += rut % 10 * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - suma % 11;
            var @return = suma == 10 ? "K" : suma.ToString();
            return suma == 11 ? "0" : @return;
        }
    }
}
