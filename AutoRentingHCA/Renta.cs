using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRentingHCA
{
    public class Renta
    {
        public int IDRENTA { get; set; }
        public int IDAUTOS { get; set; }
        public string CEDULA { get; set; }
        public string telefono { get; set; }
        public DateTime FECHAREGISTRORENTA { get; set; }
        public DateTime FECHARESERVARENTA { get; set; }
        public int DIASRENTA { get; set; }
        public string DIRECCIONRENTA { get; set; }
        public double TOTALRENTA { get; set; }

    }
}
