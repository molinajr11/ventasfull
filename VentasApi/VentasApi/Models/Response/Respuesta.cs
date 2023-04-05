namespace VentasApi.Models.Response
{
    public class Respuesta
    {
        public int Exito { get; set; } 
        public string Mensjae { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            this.Exito = 0;
        }
    }
}
