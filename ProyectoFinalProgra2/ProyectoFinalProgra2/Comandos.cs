using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgra2
{
    class Comandos
    {
        public string rem { get;}
        public string input { get; }
        public string let { get; }
        public string print { get; }
        public string goTo { get; }
        public string ifGoto { get; }
        public string end { get; }

        public Comandos()
        {
            this.rem = "rem";
            this.input = "input";
            this.let = "let";
            this.print = "print";
            this.goTo = "goto";
            this.ifGoto = "if...goto";
            this.end = "end";
        }
    }
}
