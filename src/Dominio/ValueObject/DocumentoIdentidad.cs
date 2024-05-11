using Domain.Excepcions;
using System.Text.RegularExpressions;

namespace Domain.ValueObject
{
    public class DocumentoIdentidad
    {
        public DocumentoIdentidad() { }
        public int Documento { get; private set; }
        public string Digito { get; private set; }
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
        }
        private bool ValidarRut(string rut)
        {
            try
            {
                rut = rut.Replace(".", "").ToUpper();
                var expresion = new Regex("^([0-9]+-[0-9K])$");
                if (!expresion.IsMatch(rut))
                    return false;
                var rutParts = rut.Split('-');
                if (rutParts.Length != 2)
                    return false;
                if (!int.TryParse(rutParts[0], out int documento))
                    return false;
                Documento = documento;
                Digito = rutParts[1];
                return Digito == Digit(Documento);
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
