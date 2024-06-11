using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploHTTP.Models
{
    public class Post
    {
        //Formas de criar os atributos/propriedades
        //Clicar como botão direito, Quick Actions...,  Encapsulate field
        private int id;
        public int Id { get => id; set => id = value; }

        //Escrever prop alterar o nome da propriedade gerada
        public int UserId { get; set; }
        public int Title { get; set; }
        public int Body { get; set; }
    }
}
